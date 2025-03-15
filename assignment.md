# BeSpoked Bikes Assignment

BeSpoked Bikes is looking to create a sales tracking application.  BeSpoked is a high-end bicycle shop and each salesperson gets a commission for each bike they sell.  They are introducing a new quarterly bonus based on sales as an incentive.

They are asking you to design a simple sales tracking application to help track the commission and determine each salesperson's quarterly bonus.

They will need at a minimum the following components:

## Data layer

### Entities

- Products (Name, Manufacturer, Style, Purchase Price, Sale Price, Qty On Hand, Commission Percentage)
- Salesperson (First Name, Last Name, Address, Phone, Start Date, Termination Date, Manager)
- Customer (First Name, Last Name, Address, Phone, Start Date)
- Sales (Product, Salesperson, Customer, Sales Date)
- Discount (Product, Begin Date, End Date, Discount Percentage)

- Seed with sample data for testing

## Middle tier

- Allows for client access to the data layer

## Client

- Display a list of salespersons
- Update a salesperson
- Display a list of products
- Update a product
- Display a list of customers
- Display a list of sales.  Optionally filter by date range.  This should include the Product, Customer, Date, Price, Salesperson, and Salesperson Commission.
- Create a sale
- Display a quarterly salesperson commission report

## Additional Requirements

- Products (No duplicate product can be entered.)
- Salespersons (No duplicate salesperson can be entered.)

## Non-functional Requirements

- Publish the source code to an online source code repository of your choosing.
- Optional: Host in Azure.
