namespace DbProject.Database.Dao;

public class OrdersTable : Table
{
    public OrdersTable() : base("orders")
    {
        Id();
        Reference("pc_type_id", typeof(PcTypeTable));
        Reference("payment_method_id", typeof(PaymentMethodTable));
        Reference("customer_id", typeof(CustomerTable));
        Reference("employee_id", typeof(EmployeeTable));
        Varchar("order_id");
        Date("order_date");
        Float("price");
    }
}