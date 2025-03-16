import { ReactNode } from "react";
import { Label } from "@/components/ui/label";
import { Input } from "@/components/ui/input";

interface FormFieldProps {
  id: string;
  label: string;
  error?: string;
  children?: ReactNode;
  className?: string;
  required?: boolean;
  description?: string;
}

export function FormField({
  id,
  label,
  error,
  children,
  className = "",
  required = false,
  description,
}: FormFieldProps) {
  return (
    <div className={`space-y-2 ${className}`}>
      <Label htmlFor={id} className="flex gap-1 items-center">
        <span>{label}</span>
        {required && <span className="text-red-500">*</span>}
      </Label>
      
      {description && (
        <p className="text-xs text-muted-foreground">{description}</p>
      )}
      
      {children}
      
      {error && <p className="text-sm text-red-500">{error}</p>}
    </div>
  );
}

interface InputFieldProps {
  id: string;
  label: string;
  type?: string;
  value: string | number;
  onChange: (e: React.ChangeEvent<HTMLInputElement>) => void;
  error?: string;
  placeholder?: string;
  required?: boolean;
  className?: string;
  description?: string;
  min?: number;
  max?: number;
  step?: number;
  disabled?: boolean;
}

export function InputField({
  id,
  label,
  type = "text",
  value,
  onChange,
  error,
  placeholder,
  required = false,
  className = "",
  description,
  min,
  max,
  step,
  disabled = false,
}: InputFieldProps) {
  return (
    <FormField 
      id={id} 
      label={label} 
      error={error} 
      className={className}
      required={required}
      description={description}
    >
      <Input
        id={id}
        name={id}
        type={type}
        value={value}
        onChange={onChange}
        placeholder={placeholder}
        required={required}
        min={min}
        max={max}
        step={step}
        disabled={disabled}
      />
    </FormField>
  );
}

interface SelectFieldProps {
  id: string;
  label: string;
  value: string | number;
  onChange: (e: React.ChangeEvent<HTMLSelectElement>) => void;
  options: Array<{ value: string | number; label: string }>;
  error?: string;
  required?: boolean;
  placeholder?: string;
  className?: string;
  description?: string;
  disabled?: boolean;
}

export function SelectField({
  id,
  label,
  value,
  onChange,
  options,
  error,
  required = false,
  placeholder = "Select an option",
  className = "",
  description,
  disabled = false,
}: SelectFieldProps) {
  return (
    <FormField 
      id={id} 
      label={label} 
      error={error} 
      className={className}
      required={required}
      description={description}
    >
      <select
        id={id}
        name={id}
        value={value}
        onChange={onChange}
        required={required}
        disabled={disabled}
        className="w-full h-10 px-3 py-2 rounded-md border border-input bg-[hsl(var(--background))]"
      >
        <option value="">{placeholder}</option>
        {options.map((option) => (
          <option key={option.value} value={option.value}>
            {option.label}
          </option>
        ))}
      </select>
    </FormField>
  );
}