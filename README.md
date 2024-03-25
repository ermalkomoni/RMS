# **Troja Restaurant**

## **Overview**

**Troja Restaurant** is a cross-platform web application built with .NET MVC that enables users to purchase food, make online reservations, and process payments securely through Stripe. The application is designed to provide a seamless and user-friendly experience for customers, allowing them to browse the menu, place orders, and make reservations with ease.

## **Live URL**

The application is hosted on Azure and can be accessed via the following link: [Troja Restaurant](https://troja.azurewebsites.net/)

## **Features**

- **Menu**: Browse through a variety of dishes and beverages offered by **Troja Restaurant**.
- **Ordering**: Place orders for food and beverages directly from the menu.
- **Reservations**: Make online reservations for dining at the restaurant.
- **Payment**: Process payments securely through Stripe.
- **Notifications**: Receive notifications for order confirmation and reservation reminders via Twilio API.
- **User Experience**: Enjoy a smooth and intuitive user experience with the help of Toastr, SweetAlert, and OWL Carousel libraries.

## **Frameworks and Libraries**

- **Frameworks**: .NET MVC
- **Libraries**: Toastr, SweetAlert, OWL Carousel

## **Integrated APIs**

- **Stripe API**: For secure payment processing.
- **Twilio API**: For sending notifications to users.

## **Architecture and Design Patterns**

- **N-tier Architecture**: The application follows an N-tier architecture, separating the presentation layer, business logic layer, and data access layer for better maintainability and scalability.
- **Unit of Work**: The application uses the Unit of Work pattern to manage transactions and ensure data consistency.

## **Getting Started**

To run the application locally, follow these steps:

1. Clone the repository: `git clone https://github.com/ermalkomoni/RMS`
2. Navigate to the project directory: `cd troja-restaurant`
3. Install dependencies: `dotnet restore`
4. Build the project: `dotnet build`
5. Run the application: `dotnet run`

## **Contributing**

Contributions are welcome! If you have any suggestions, bug reports, or feature requests, please open an issue on the GitHub repository.
