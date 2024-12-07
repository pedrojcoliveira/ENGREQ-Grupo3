# Story Mapping for AMAPP Web Application

## **Epic 1: Producer Catalog Management**

### **Activity 1: Create and Manage Product Catalog**

**MVP (Minimum Viable Product):**

* **US1-TASK01:** Develop `<span>ProductProfile</span>` and `<span>ProductRepository</span>` to manage product data.
* **US1-TASK02:** Implement `<span>ProductsController</span>` for CRUD operations.
* **US1-TASK03:** Create views: `<span>CreateProducts.cshtml</span>` and `<span>EditProducts.cshtml</span>`.

**MVI1 (Minimum Viable Increment 1):**

* **US1-TASK04:** Enhance UI for product listing with filters and sorting options.

**MVI2 (Minimum Viable Increment 2):**

* **US1-TASK05:** Add a bulk upload feature for product data.
* **US1-TASK06:** Enable integration with external product catalogs.

**Backlog:**

* **US1-TASK07:** Implement advanced analytics for product performance.
* **US1-TASK08:** Provide export functionality for product catalogs.

### **Justification for Prioritization:**

1. **Core Need:** Producers require a reliable way to manage their product catalogs for business operations. The MVP focuses on essential CRUD operations.
2. **Incremental Improvements:** MVI1 and MVI2 introduce advanced functionality for efficiency and integration.
3. **Backlog:** Features like analytics and exports are planned for enhanced usability and insights.

---

## **Epic 2: Subscription Periods**

### **Activity 1: Define and Notify Subscription Periods**

**MVP (Minimum Viable Product):**

* **US2-TASK01:** Use `<span>SubscriptionPeriodService</span>` for creating and updating periods.
* **US2-TASK02:** Implement notifications using `<span>SubscriptionPeriodCreatedEventHandler</span>`.
* **US2-TASK03:** Create `<span>SubscriptionPeriodProfile</span>` for data mapping.

**MVI1 (Minimum Viable Increment 1):**

* **US2-TASK04:** Develop a calendar view for visualizing subscription periods.
* **US2-TASK05:** Add email reminders for producers about upcoming periods.

**MVI2 (Minimum Viable Increment 2):**

* **US2-TASK06:** Enable recurring subscription period setup.
* **US2-TASK07:** Integrate with external scheduling tools.

**Backlog:**

* **US2-TASK08:** Provide advanced analytics for subscription period trends.

### **Justification for Prioritization:**

1. **Core Need:** Managers must define and communicate subscription periods effectively. MVP ensures basic functionality.
2. **Incremental Improvements:** Visual tools in MVI1 enhance usability, while MVI2 focuses on automation.
3. **Backlog:** Analytics offer long-term strategic value.

---

## **Epic 3: Product Offer Management**

### **Activity 1: Create and Manage Product Offers**

**MVP (Minimum Viable Product):**

* **US3-TASK01:** Use `<span>ProductOfferService</span>` and `<span>ProductOfferRepository</span>` to manage offers.
* **US3-TASK02:** Add functionality in `<span>ProductOfferProfile</span>` for mapping offers.
* **US3-TASK03:** Create Razor views for listing and editing offers.

**MVI1 (Minimum Viable Increment 1):**

* **US3-TASK04:** Enhance UI for offer management with filters and sorting.
* **US3-TASK05:** Add validation for payment options.

**MVI2 (Minimum Viable Increment 2):**

* **US3-TASK06:** Enable batch creation of product offers.
* **US3-TASK07:** Integrate with pricing recommendation tools.

**Backlog:**

* **US3-TASK08:** Implement analytics for offer performance.

### **Justification for Prioritization:**

1. **Core Need:** Producers must create and manage product offers. MVP ensures basic functionality.
2. **Incremental Improvements:** MVI1 and MVI2 focus on usability and automation.
3. **Backlog:** Analytics provide long-term insights for strategic decision-making.

---

## **Epic 4: Subscription by Co-Producers**

### **Activity 1: Subscribe to Product Offers**

**MVP (Minimum Viable Product):**

* **US4-TASK01:** Implement `<span>SelectedProductOfferService</span>` for managing subscriptions.
* **US4-TASK02:** Create views for listing and selecting product offers.

**MVI1 (Minimum Viable Increment 1):**

* **US4-TASK03:** Add validation for subscription quantities.
* **US4-TASK04:** Enable notifications for successful subscriptions.

**MVI2 (Minimum Viable Increment 2):**

* **US4-TASK05:** Provide a dashboard for managing subscriptions.
* **US4-TASK06:** Integrate with payment systems for automated invoicing.

**Backlog:**

* **US4-TASK07:** Offer subscription analytics and trends.

### **Justification for Prioritization:**

1. **Core Need:** Co-Producers must subscribe to product offers easily. MVP establishes basic functionality.
2. **Incremental Improvements:** MVI1 and MVI2 enhance usability and integration with financial tools.
3. **Backlog:** Analytics support long-term subscription strategy.

---

## **Epic 5: Payment and Balances Calculation**

### **Activity 1: Calculate and Manage Payments**

**MVP (Minimum Viable Product):**

* **US5-TASK01:** Use `<span>SubscriptionRepository</span>` for storing subscription data.
* **US5-TASK02:** Add calculation logic in `<span>SubscriptionService</span>`.

**MVI1 (Minimum Viable Increment 1):**

* **US5-TASK03:** Develop a payment summary view.
* **US5-TASK04:** Enable notifications for payment due dates.

**MVI2 (Minimum Viable Increment 2):**

* **US5-TASK05:** Integrate with third-party payment gateways.

**Backlog:**

* **US5-TASK06:** Provide detailed financial reports.

### **Justification for Prioritization:**

1. **Core Need:** Accurate payment calculation and tracking are critical. MVP ensures functionality.
2. **Incremental Improvements:** MVI1 and MVI2 enhance usability and automation.
3. **Backlog:** Financial reports offer strategic insights.

---

## **Epic 6: Product Delivery Management**

### **Activity 1: Manage Delivery Adjustments**

**MVP (Minimum Viable Product):**

* **US6-TASK01:** Extend `<span>DeliveryDateRepository</span>` to handle delivery adjustments.
* **US6-TASK02:** Develop UI components for updating delivery information.

**MVI1 (Minimum Viable Increment 1):**

* **US6-TASK03:** Add notifications for delivery changes to all stakeholders.
* **US6-TASK04:** Implement a dashboard for monitoring delivery statuses.

**MVI2 (Minimum Viable Increment 2):**

* **US6-TASK05:** Integrate with logistics APIs for real-time tracking.
* **US6-TASK06:** Enable automated alerts for late or missed deliveries.

**Backlog:**

* **US6-TASK07:** Provide predictive analytics for optimizing delivery routes.

### **Justification for Prioritization:**

1. **Core Need:** Producers and managers must handle and monitor delivery updates efficiently. MVP provides basic functionality.
2. **Incremental Improvements:** MVI1 introduces stakeholder notifications and monitoring tools, while MVI2 integrates real-time tracking.
3. **Backlog:** Analytics enhance long-term delivery efficiency.

---

## **Epic 7: KPI Dashboard**

### **Activity 1: Visualize Critical Metrics**

**MVP (Minimum Viable Product):**

* **US7-TASK01:** Use `<span>SubscriptionRepository</span>` and `<span>ProductRepository</span>` for data aggregation.
* **US7-TASK02:** Create views for KPI visualization, including metrics like total value delivered by Producer.

**MVI1 (Minimum Viable Increment 1):**

* **US7-TASK03:** Add filtering options for metrics by date or producer.
* **US7-TASK04:** Enable export of KPI reports.

**MVI2 (Minimum Viable Increment 2):**

* **US7-TASK05:** Integrate with external analytics platforms.
* **US7-TASK06:** Implement real-time KPI updates.

**Backlog:**

* **US7-TASK07:** Provide predictive analytics for future performance trends.

### **Justification for Prioritization:**

1. **Core Need:** Managers need insights into key business metrics. MVP ensures basic visualizations.
2. **Incremental Improvements:** MVI1 and MVI2 add filtering, reporting, and real-time updates for greater utility.
3. **Backlog:** Predictive analytics support long-term strategy.

---

## **Epic 8: Account Balancing**

### **Activity 1: Calculate and Update Balances**

**MVP (Minimum Viable Product):**

* **US8-TASK01:** Add logic in `<span>SelectedProductOfferService</span>` for balance updates after each delivery.
* **US8-TASK02:** Integrate with `<span>SubscriptionRepository</span>` for financial tracking.

**MVI1 (Minimum Viable Increment 1):**

* **US8-TASK03:** Develop a balance summary view for Producers and Co-Producers.
* **US8-TASK04:** Add notifications for updated balances.

**MVI2 (Minimum Viable Increment 2):**

* **US8-TASK05:** Enable automated reconciliation of account balances.
* **US8-TASK06:** Integrate with external accounting systems.

**Backlog:**

* **US8-TASK07:** Provide advanced financial forecasting tools.

### **Justification for Prioritization:**

1. **Core Need:** Accurate account balancing is essential for financial transparency. MVP provides fundamental calculations.
2. **Incremental Improvements:** MVI1 enhances visibility and communication, while MVI2 focuses on automation and integration.
3. **Backlog:** Financial forecasting adds strategic insights for future planning.
