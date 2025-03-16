/**
 * Format currency for display
 * @param amount - The amount to format
 * @param locale - The locale to use (defaults to en-US)
 * @param currency - The currency to use (defaults to USD)
 * @returns Formatted currency string
 */
export function formatCurrency(
  amount: number, 
  locale = "en-US", 
  currency = "USD"
): string {
  return new Intl.NumberFormat(locale, {
    style: "currency",
    currency: currency,
  }).format(amount);
}

/**
 * Format date for display
 * @param date - The date to format (string or Date)
 * @param locale - The locale to use (defaults to en-US)
 * @returns Formatted date string
 */
export function formatDate(
  date: string | Date, 
  locale = "en-US"
): string {
  const dateObj = typeof date === "string" ? new Date(date) : date;
  return new Intl.DateTimeFormat(locale, {
    year: "numeric",
    month: "short",
    day: "numeric",
  }).format(dateObj);
}

/**
 * Format percentage for display
 * @param value - The percentage value (0-100)
 * @param decimalPlaces - Number of decimal places to show
 * @returns Formatted percentage string
 */
export function formatPercentage(
  value: number,
  decimalPlaces = 1
): string {
  return `${value.toFixed(decimalPlaces)}%`;
}

/**
 * Format phone number for display
 * @param phone - The phone number to format
 * @returns Formatted phone number
 */
export function formatPhone(phone: string): string {
  // Remove all non-numeric characters
  const cleaned = phone.replace(/\D/g, "");
  
  // Format as (XXX) XXX-XXXX if it's a 10-digit number
  if (cleaned.length === 10) {
    return `(${cleaned.slice(0, 3)}) ${cleaned.slice(3, 6)}-${cleaned.slice(6)}`;
  }
  
  // Otherwise return the original value
  return phone;
}