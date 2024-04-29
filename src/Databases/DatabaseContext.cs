using BackendTeamwork.Entities;

namespace BackendTeamwork.Databases
{
    public class DatabaseContext
    {
        public IEnumerable<User> Users;
        public IEnumerable<Payment> Payments;

        public IEnumerable<Address> Addresses;

        public DatabaseContext()
        {
            this.Users =
            [
                new User(
                    new Guid("11111111-1111-1111-1111-111111111111"),
                    "Almuhannad",
                    "Almhari",
                    "Almuhannad@example.com",
                    "12345",
                    "1234567890",
                    "Admin",
                    new Guid(),
                    new Guid()
                ),
                new User(
                    new Guid("22222222-2222-2222-2222-222222222222"),
                    "Almuhannad",
                    "Almhari",
                    "Almuhannad@example.com",
                    "12345",
                    "1234567890",
                    "Admin",
                    new Guid("99999999-9999-9999-9999-999999999999"),
                    new Guid()
                ),
                new User(
                    new Guid("33333333-3333-3333-3333-333333333333"),
                    "Almuhannad",
                    "Almhari",
                    "Almuhannad@example.com",
                    "12345",
                    "1234567890",
                    "Admin",
                    new Guid(),
                    new Guid()
                ),
                new User(
                    new Guid("44444444-4444-4444-4444-444444444444"),
                    "Almuhannad",
                    "Almhari",
                    "Almuhannad@example.com",
                    "12345",
                    "1234567890",
                    "Admin",
                    new Guid(),
                    new Guid()
                ),
                new User(
                    new Guid("55555555-5555-5555-5555-555555555555"),
                    "Almuhannad",
                    "Almhari",
                    "Almuhannad@example.com",
                    "12345",
                    "1234567890",
                    "Admin",
                    new Guid(),
                    new Guid()
                ),
            ];

            this.Payments = [
                new Payment (new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),145678923,"Cash",new DateTime(), new Guid()),
                new Payment (new Guid(),456,"free",new DateTime(), new Guid()),
                new Payment (new Guid(),789,"visa",new DateTime(), new Guid()),

                    ];
            this.Addresses = [
                new Address(new Guid("99999999-9999-9999-9999-999999999999"), "Riyadh", "12461", "Hisham Ibn Abd Al Malek, Al Mursalat", new Guid("22222222-2222-2222-2222-222222222222"))
            ];
        }


    }
}