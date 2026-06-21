Add Migration with this command:
    dotnet ef migrations add AddPaymentDetail --project WebPayment.Services --startup-project WebPayment.Server -o Migrations

UPDATE  Database with this command
    dotnet ef database update --project WebPayment.Services --startup-project WebPayment.Server
    
REMOVE Migrations
    dotnet ef migrations remove --project WebPayment.Services --startup-project WebPayment.Server