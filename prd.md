# PRD: Sales Tracking Application for BeSpoked Bikes

## 1. Product overview

### 1.1 Document title and version

- PRD: Sales Tracking Application for BeSpoked Bikes
- Version: 1.0

### 1.2 Product summary

BeSpoked Bikes, a high-end bicycle shop, is launching a new quarterly bonus system based on sales to motivate their salespeople. To support this initiative, they need a simple sales tracking application to monitor sales, calculate commissions for each bike sold, and determine quarterly bonuses. The application will feature a data layer with entities for products, salespersons, customers, sales, and discounts, seeded with sample data for testing. A middle tier will connect the client to the data layer, while the client will offer interfaces to view and manage data, including updating salespersons and products, recording sales, and generating a quarterly commission report.

The application aims to streamline sales tracking, ensure accurate commission and bonus calculations, and provide actionable insights into sales performance. Built with Vite (React 18), shadcn for UI, .NET Core 8.0, and Microsoft SQL Server, it will be intuitive and efficient, with source code published to an online repository and an optional Azure hosting feature.

## 2. Goals

### 2.1 Business goals

- Boost sales performance with a quarterly bonus system.
- Ensure accurate tracking of sales and commissions for fair compensation.
- Improve data management for products, salespersons, customers, and sales.
- Offer sales performance insights via reports.

### 2.2 User goals

- Salespersons: Easily monitor their sales and commissions.
- Managers: Track team sales performance and commission payouts.
- Administrators: Efficiently manage product, salesperson, and customer data.

### 2.3 Non-goals

- Managing inventory beyond basic quantity on hand.
- Providing advanced CRM features.
- Integrating with external systems like accounting software.

## 3. User personas

### 3.1 Key user types

- Salespersons
- Managers
- Administrators

### 3.2 Basic persona details

- Salespersons: Employees selling bikes and earning commissions.
- Managers: Supervisors monitoring sales team performance.
- Administrators: Staff managing application data and settings.

### 3.3 Role-based access

- **Salespersons**: View their own sales, commissions, and quarterly bonus reports.
- **Managers**: Access all sales data, commissions, and generate team reports.
- **Administrators**: Manage products, salespersons, customers, and discounts.

## 4. Functional requirements

- **Data Management** (Priority: High)
  - Support CRUD operations for products, salespersons, customers, and discounts.
  - Prevent duplicate entries for products and salespersons.
- **Sales Tracking** (Priority: High)
  - Record sales with product, salesperson, customer, and date details.
  - Auto-calculate commissions using product commission percentages.
- **Reporting** (Priority: High)
  - Generate quarterly salesperson commission reports.
  - Display lists of salespersons, products, customers, and sales, with optional date range filtering for sales.
- **User Interface** (Priority: High)
  - Deliver intuitive data entry and viewing interfaces.
  - Ensure responsiveness and user-friendliness.

## 5. User experience

### 5.1 Entry points & first-time user flow

- Users log in based on their role (salesperson, manager, administrator).
- New users land on a role-specific dashboard after login.

### 5.2 Core experience

- **Login**: Users enter credentials to access the app.
  - Secure authentication ensures data protection.
- **Dashboard**: Role-tailored dashboard with key metrics and links.
  - Salespersons see recent sales and commission summaries; managers see team overviews; administrators see data tools.
- **Data Management**: Administrators add, edit, or delete entities.
  - Forms include validation to avoid errors and duplicates.
- **Sales Recording**: Salespersons log new sales.
  - Simple selection of product, customer, and date auto-calculates commissions.
- **Reporting**: Managers view and generate quarterly commission reports.
  - Reports are clear, exportable, and printable.

### 5.3 Advanced features & edge cases

- Manage commissions for terminated salespersons with pending payments.
- Handle overlapping discount periods for the same product.
- Maintain data integrity during price or commission updates.

### 5.4 UI/UX highlights

- Modern, clean design with shadcn UI components.
- Responsive layout for all devices.
- Clear navigation with intuitive labels and guidance.

## 6. Narrative

John, a salesperson at BeSpoked Bikes, wants to track his sales and commissions easily because he’s excited about the new quarterly bonus system. He logs into the sales tracking application, where his dashboard instantly shows recent sales and earned commissions. Recording a new sale is quick—he selects the product, customer, and date, and the commission calculates itself. At quarter’s end, his manager generates a report to award bonuses, relying on the app’s accurate, up-to-date data. This seamless process keeps John motivated and his manager informed.

## 7. Success metrics

### 7.1 User-centric metrics

- User satisfaction score for ease of use.
- Average time to record a sale.
- Number of support tickets for data entry issues.

### 7.2 Business metrics

- Sales volume increase post-bonus system launch.
- Commission calculation accuracy.
- Time saved on manual sales tracking.

### 7.3 Technical metrics

- Application uptime and reliability.
- Data query response time.
- Data integrity and consistency.

## 8. Technical considerations

### 8.1 Integration points

- Possible integration with existing customer databases.
- Future potential for accounting software compatibility.

### 8.2 Data storage & privacy

- Store data in Microsoft SQL Server.
- Use encryption and access controls for sensitive data.

### 8.3 Scalability & performance

- Support growing sales and user volumes.
- Optimize database queries for fast responses.

### 8.4 Potential challenges

- Maintaining data consistency across entities.
- Managing concurrent product quantity updates.
- Preserving historical data for terminated salespersons.

## 9. Milestones & sequencing

### 9.1 Project estimate

- Medium: 2-4 weeks

### 9.2 Team size & composition

- Medium Team: 1-3 total people
  - Product manager, 1-2 engineers, 1 designer, 1 QA specialist

### 9.3 Suggested phases

- **Phase 1**: Build core data management and sales recording (2 weeks)
  - Key deliverables: CRUD operations, sales entry interface.
- **Phase 2**: Add reporting and UI enhancements (1 week)
  - Key deliverables: Commission report, dashboards.
- **Phase 3**: Test, fix bugs, and deploy (1 week)
  - Key deliverables: Fully functional app, documentation.

## 10. User stories

### 10.1 View salespersons list

- **ID**: US-001
- **Description**: As an administrator, I want to view a list of all salespersons so that I can manage their information.
- **Acceptance criteria**:
  - List shows first name, last name, address, phone, start date, termination date, and manager.
  - Sortable by name and start date.

### 10.2 Update salesperson information

- **ID**: US-002
- **Description**: As an administrator, I want to update a salesperson’s details to keep them current.
- **Acceptance criteria**:
  - Editable fields: first name, last name, address, phone, start date, termination date, manager.
  - Validation blocks invalid data (e.g., future termination dates).

### 10.3 View products list

- **ID**: US-003
- **Description**: As an administrator, I want to view all products to manage inventory and pricing.
- **Acceptance criteria**:
  - Displays name, manufacturer, style, purchase price, sale price, quantity on hand, and commission percentage.
  - Filterable by manufacturer or style.

### 10.4 Update product information

- **ID**: US-004
- **Description**: As an administrator, I want to update product details for pricing or commission changes.
- **Acceptance criteria**:
  - Editable fields exclude name to avoid duplicates.
  - Changes logged for audit tracking.

### 10.5 View customers list

- **ID**: US-005
- **Description**: As an administrator, I want to view all customers to manage their data.
- **Acceptance criteria**:
  - Shows first name, last name, address, phone, and start date.
  - Searchable by name or phone.

### 10.6 View sales list

- **ID**: US-006
- **Description**: As a manager, I want to view all sales to monitor performance.
- **Acceptance criteria**:
  - Includes product, salesperson, customer, date, price, and commission.
  - Filterable by date range.
  - Sortable by date or salesperson.

### 10.7 Create a sale

- **ID**: US-007
- **Description**: As a salesperson, I want to record a sale to track my commissions.
- **Acceptance criteria**:
  - Select product, customer, and date.
  - Commission auto-calculates from product percentage.
  - Requires all fields to be completed.

### 10.8 Generate quarterly commission report

- **ID**: US-008
- **Description**: As a manager, I want to generate a quarterly commission report to award bonuses.
- **Acceptance criteria**:
  - Shows total sales, commissions, and bonus eligibility per salesperson.
  - Filterable by quarter and year.
  - Exportable to PDF or Excel.

### 10.9 Prevent duplicate product entry

- **ID**: US-009
- **Description**: As an administrator, I want to block duplicate products for data integrity.
- **Acceptance criteria**:
  - Checks product name before saving.
  - Displays error if duplicate is found.

### 10.10 Prevent duplicate salesperson entry

- **ID**: US-010
- **Description**: As an administrator, I want to avoid duplicate salespersons to prevent confusion.
- **Acceptance criteria**:
  - Checks name or ID before saving.
  - Shows error if duplicate detected.

### 10.11 Secure access to the application

- **ID**: US-011
- **Description**: As a user, I want secure login to access features based on my role.
- **Acceptance criteria**:
  - Requires valid credentials.
  - Role-based access limits functionality (e.g., salespersons can’t edit products).
  - Encrypts and securely stores passwords.