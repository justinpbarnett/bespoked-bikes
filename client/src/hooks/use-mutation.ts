import { useMutation, useQueryClient } from "@tanstack/react-query";

interface MutationOptions<TData, TError, TVariables, TContext> {
  mutationFn: (variables: TVariables) => Promise<TData>;
  onMutate?: (variables: TVariables) => Promise<TContext> | TContext;
  onSuccess?: (data: TData, variables: TVariables, context: TContext | undefined) => void;
  onError?: (error: TError, variables: TVariables, context: TContext | undefined) => void;
  onSettled?: (
    data: TData | undefined,
    error: TError | null,
    variables: TVariables,
    context: TContext | undefined
  ) => void;
  invalidateQueries?: string[];
  setQueryData?: {
    queryKey: string[];
    updater: (oldData: any, data: TData) => any;
  };
}

/**
 * A custom hook for handling mutations with common patterns
 */
export function useMutationWithInvalidation<TData, TError = unknown, TVariables = void, TContext = unknown>({
  mutationFn,
  onMutate,
  onSuccess,
  onError,
  onSettled,
  invalidateQueries = [],
  setQueryData,
}: MutationOptions<TData, TError, TVariables, TContext>) {
  const queryClient = useQueryClient();

  return useMutation({
    mutationFn,
    onMutate,
    onSuccess: (data, variables, context) => {
      // Update specific query data if provided
      if (setQueryData) {
        queryClient.setQueryData(
          setQueryData.queryKey, 
          (oldData: any) => setQueryData.updater(oldData, data)
        );
      }

      // Invalidate queries
      if (invalidateQueries.length > 0) {
        invalidateQueries.forEach(queryKey => {
          queryClient.invalidateQueries({ queryKey: [queryKey] });
        });
      }

      // Call the provided onSuccess callback
      onSuccess?.(data, variables, context as TContext);
    },
    onError,
    onSettled,
  });
}