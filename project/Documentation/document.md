# Story Mapping for AMAPP Web Application

## **Epics and User Stories**

### **Epic 1: Producer Catalog Management**

* **User Story 1**: As a Producer, I want to define my product catalog with details like name, description, photo, reference price, and delivery units.
  * **Tasks**:
    * Develop the `<span>ProductProfile</span>` and `<span>ProductRepository</span>` for data handling.
    * Implement `<span>ProductsController</span>` to manage HTTP requests.
    * Create `<span>CreateProducts.cshtml</span>` and `<span>EditProducts.cshtml</span>` for UI forms.

### **Epic 2: Subscription Periods**

* **User Story 2**: As a Manager, I want to define subscription periods with start and end dates and notify producers.
  * **Tasks**:
    * Use `<span>SubscriptionPeriodService</span>` for subscription period creation and updates.
    * Integrate with `<span>SubscriptionPeriodCreatedEventHandler</span>` for automatic notifications.
    * Build a `<span>SubscriptionPeriodProfile</span>` for mapping data.

### **Epic 3: Product Offer Management**

* **User Story 3**: As a Producer, I want to create offers for specific periods and specify payment options.
  * **Tasks**:
    * Leverage `<span>ProductOfferService</span>` and `<span>ProductOfferRepository</span>` to manage offers.
    * Add functionality in `<span>ProductOfferProfile</span>` for mapping offers.
    * Create corresponding Razor views for listing and editing offers.

### **Epic 4: Subscription by Co-Producers**

* **User Story 4**: As a Co-Producer, I want to subscribe to product offers, specifying quantities and payment options.
  * **Tasks**:
    * Implement a `<span>SelectedProductOfferService</span>` for managing subscriptions.
    * Build views like `<span>ListProducts.cshtml</span>` for selection and subscription.

### **Epic 5: Payment and Balances Calculation**

* **User Story 5**: As a Manager, I want to calculate payments due and balances for Producers and Co-Producers.
  * **Tasks**:
    * Use `<span>SubscriptionRepository</span>` for storing subscriptions and payments.
    * Add calculation logic to `<span>SubscriptionService</span>`.

### **Epic 6: Product Delivery Management**

* **User Story 6**: As a Producer, I want to manage product delivery, adjusting quantities as needed.
  * **Tasks**:
    * Extend `<span>DeliveryDateRepository</span>` for handling delivery adjustments.
    * Create UI components for updating delivery information.

### **Epic 7: KPI Dashboard**

* **User Story 7**: As a Manager, I want to view critical KPIs like total value delivered by Producer and average value per Co-Producer.
  * **Tasks**:
    * Use `<span>SubscriptionRepository</span>` and `<span>ProductRepository</span>` for data aggregation.
    * Develop a dedicated dashboard in Razor views.

### **Epic 8: Account Balancing**

* **User Story 8**: As a Manager, I want to calculate and update account balances for Co-Producers after each delivery.
  * **Tasks**:
    * Add logic in `<span>SelectedProductOfferService</span>` for balance updates.
    * Integrate with `<span>SubscriptionRepository</span>` for financial tracking.

## **Mapping Observations from Code**

### Controllers:

* `<span>HomeController</span>`: Likely responsible for general navigation and initial setup.
* `<span>ProductsController</span>`: Handles CRUD operations for products, aligning with Epic 1.

### Services:

* `<span>SubscriptionPeriodCreatedEventHandler</span>`: Focuses on notifications and subscription events, supporting Epic 2.
* `<span>ProductOfferService</span>`: Manages product offers, tying to Epic 3.

### Views:

* `<span>ListProducts.cshtml</span>`: Supports product listing, likely used in Epics 1, 3, and 4.
* `<span>CreateProducts.cshtml</span>` and `<span>EditProducts.cshtml</span>`: Designed for product management in Epic 1.
* `<span>Login.cshtml</span>` and `<span>Register.cshtml</span>`: Handle authentication, which is an ancillary functionality supporting all epics.

## **Story Map Layout**

### Backbone:

1. Producer Catalog Management
2. Subscription Periods
3. Product Offer Management
4. Subscription by Co-Producers
5. Payment and Balances Calculation
6. Product Delivery Management
7. KPI Dashboard
8. Account Balancing

### Tasks:

Each epic above includes its related tasks, as outlined in the epics and user stories section.

## **Next Steps**

1. Continue building views for missing functionalities.
2. Expand services for enhanced data handling and automation.
3. Validate current implementation against user stories for completeness.
