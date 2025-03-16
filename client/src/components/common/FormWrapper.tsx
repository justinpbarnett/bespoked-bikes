import { ReactNode } from "react";
import { Button } from "@/components/ui/button";
import { X } from "lucide-react";

interface FormWrapperProps {
  title: string;
  onClose: () => void;
  error?: string | null;
  children: ReactNode;
  isSubmitting?: boolean;
  onSubmit?: (e: React.FormEvent) => void;
  submitLabel?: string;
  warning?: string | ReactNode;
}

export default function FormWrapper({
  title,
  onClose,
  error,
  children,
  isSubmitting = false,
  onSubmit,
  submitLabel = "Submit",
  warning,
}: FormWrapperProps) {
  return (
    <div className="bg-card p-6 rounded-lg shadow mb-6">
      <div className="flex justify-between items-center mb-4">
        <h2 className="text-xl font-semibold">{title}</h2>
        <Button variant="ghost" size="sm" onClick={onClose}>
          <X className="w-4 h-4" />
        </Button>
      </div>

      {error && (
        <div className="bg-red-50 text-red-600 p-3 rounded-md mb-4">
          {error}
        </div>
      )}

      {warning && (
        <div className="bg-yellow-50 text-yellow-600 p-3 rounded-md mb-4">
          {warning}
        </div>
      )}

      {onSubmit ? (
        <form onSubmit={onSubmit} className="space-y-4">
          {children}
          <div className="flex justify-end space-x-2 pt-4">
            <Button variant="outline" type="button" onClick={onClose}>
              Cancel
            </Button>
            <Button type="submit" disabled={isSubmitting}>
              {isSubmitting ? "Processing..." : submitLabel}
            </Button>
          </div>
        </form>
      ) : (
        <>
          {children}
          <div className="flex justify-end space-x-2 pt-4">
            <Button variant="outline" type="button" onClick={onClose}>
              Close
            </Button>
          </div>
        </>
      )}
    </div>
  );
}