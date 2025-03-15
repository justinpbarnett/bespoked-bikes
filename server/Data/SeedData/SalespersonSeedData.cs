using server.Models;

namespace server.Data.SeedData;

public static class SalespersonSeedData
{
    public static List<Salesperson> GetSalespersons()
    {
        return new List<Salesperson>
        {
            new Salesperson
            {
                Id = 1,
                FirstName = "John",
                LastName = "Smith",
                Address = "123 Main St, Seattle, WA 98101",
                Phone = "206-555-1234",
                StartDate = new DateTime(2020, 1, 15),
                Manager = "Emily Brown"
            },
            new Salesperson
            {
                Id = 2,
                FirstName = "Sarah",
                LastName = "Johnson",
                Address = "456 Oak Ave, Seattle, WA 98102",
                Phone = "206-555-2345",
                StartDate = new DateTime(2019, 5, 20),
                Manager = "Emily Brown"
            },
            new Salesperson
            {
                Id = 3,
                FirstName = "Michael",
                LastName = "Davis",
                Address = "789 Pine St, Seattle, WA 98103",
                Phone = "206-555-3456",
                StartDate = new DateTime(2021, 3, 10),
                Manager = "Emily Brown"
            },
            // Additional mock salespersons for pagination testing
            new Salesperson
            {
                Id = 4,
                FirstName = "Jessica",
                LastName = "Wilson",
                Address = "321 Cedar Rd, Seattle, WA 98104",
                Phone = "206-555-4567",
                StartDate = new DateTime(2021, 6, 15),
                Manager = "Emily Brown"
            },
            new Salesperson
            {
                Id = 5,
                FirstName = "David",
                LastName = "Martinez",
                Address = "654 Birch Ave, Seattle, WA 98105",
                Phone = "206-555-5678",
                StartDate = new DateTime(2022, 1, 10),
                Manager = "Emily Brown"
            },
            new Salesperson
            {
                Id = 6,
                FirstName = "Emily",
                LastName = "Taylor",
                Address = "987 Walnut St, Seattle, WA 98106",
                Phone = "206-555-6789",
                StartDate = new DateTime(2020, 8, 22),
                Manager = "Marcus Johnson"
            },
            new Salesperson
            {
                Id = 7,
                FirstName = "James",
                LastName = "Anderson",
                Address = "147 Spruce Dr, Seattle, WA 98107",
                Phone = "206-555-7890",
                StartDate = new DateTime(2019, 11, 5),
                Manager = "Marcus Johnson"
            },
            new Salesperson
            {
                Id = 8,
                FirstName = "Amanda",
                LastName = "Thomas",
                Address = "258 Maple Ln, Seattle, WA 98108",
                Phone = "206-555-8901",
                StartDate = new DateTime(2022, 3, 14),
                Manager = "Marcus Johnson"
            },
            new Salesperson
            {
                Id = 9,
                FirstName = "Daniel",
                LastName = "Rodriguez",
                Address = "369 Elm Pl, Seattle, WA 98109",
                Phone = "206-555-9012",
                StartDate = new DateTime(2021, 9, 8),
                Manager = "Marcus Johnson"
            },
            new Salesperson
            {
                Id = 10,
                FirstName = "Ashley",
                LastName = "Garcia",
                Address = "741 Oak Ct, Seattle, WA 98110",
                Phone = "206-555-0123",
                StartDate = new DateTime(2020, 5, 17),
                Manager = "Marcus Johnson"
            },
            new Salesperson
            {
                Id = 11,
                FirstName = "Robert",
                LastName = "Martinez",
                Address = "852 Cedar Pl, Seattle, WA 98111",
                Phone = "206-555-1234",
                StartDate = new DateTime(2018, 7, 23),
                Manager = "Sophia Reynolds"
            },
            new Salesperson
            {
                Id = 12,
                FirstName = "Jennifer",
                LastName = "Brown",
                Address = "963 Pine Rd, Seattle, WA 98112",
                Phone = "206-555-2345",
                StartDate = new DateTime(2019, 3, 19),
                Manager = "Sophia Reynolds"
            },
            new Salesperson
            {
                Id = 13,
                FirstName = "Christopher",
                LastName = "Lee",
                Address = "159 Birch Dr, Seattle, WA 98113",
                Phone = "206-555-3456",
                StartDate = new DateTime(2020, 10, 12),
                Manager = "Sophia Reynolds"
            },
            new Salesperson
            {
                Id = 14,
                FirstName = "Elizabeth",
                LastName = "Harris",
                Address = "357 Walnut Ave, Seattle, WA 98114",
                Phone = "206-555-4567",
                StartDate = new DateTime(2021, 2, 28),
                Manager = "Sophia Reynolds"
            },
            new Salesperson
            {
                Id = 15,
                FirstName = "Matthew",
                LastName = "Clark",
                Address = "258 Spruce St, Seattle, WA 98115",
                Phone = "206-555-5678",
                StartDate = new DateTime(2020, 4, 5),
                Manager = "Sophia Reynolds"
            },
            new Salesperson
            {
                Id = 16,
                FirstName = "Lauren",
                LastName = "Lewis",
                Address = "753 Maple Ave, Seattle, WA 98116",
                Phone = "206-555-6789",
                StartDate = new DateTime(2022, 1, 15),
                TerminationDate = new DateTime(2023, 3, 30),
                Manager = "William Phillips"
            },
            new Salesperson
            {
                Id = 17,
                FirstName = "Kevin",
                LastName = "Walker",
                Address = "951 Elm St, Seattle, WA 98117",
                Phone = "206-555-7890",
                StartDate = new DateTime(2019, 8, 7),
                Manager = "William Phillips"
            },
            new Salesperson
            {
                Id = 18,
                FirstName = "Michelle",
                LastName = "Young",
                Address = "357 Oak Rd, Seattle, WA 98118",
                Phone = "206-555-8901",
                StartDate = new DateTime(2021, 11, 22),
                Manager = "William Phillips"
            },
            new Salesperson
            {
                Id = 19,
                FirstName = "Jason",
                LastName = "Allen",
                Address = "864 Cedar St, Seattle, WA 98119",
                Phone = "206-555-9012",
                StartDate = new DateTime(2018, 5, 11),
                TerminationDate = new DateTime(2022, 11, 15),
                Manager = "William Phillips"
            },
            new Salesperson
            {
                Id = 20,
                FirstName = "Kimberly",
                LastName = "Scott",
                Address = "159 Pine Dr, Seattle, WA 98120",
                Phone = "206-555-0123",
                StartDate = new DateTime(2022, 4, 6),
                Manager = "William Phillips"
            }
        };
    }
}