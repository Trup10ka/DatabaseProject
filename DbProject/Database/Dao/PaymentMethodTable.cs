﻿namespace DbProject.Database.Dao;

public class PaymentMethodTable : Table
{
    public PaymentMethodTable() : base("payment_method")
    {
        Id();
        Varchar("name");
    }
}