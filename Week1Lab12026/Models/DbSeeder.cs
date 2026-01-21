namespace Week1Lab12026.Models
{
    public class DbSeeder
    {
        private readonly UserContext _ctx;
        private readonly IWebHostEnvironment _hosting;
        private bool disposedValue;

        public DbSeeder(UserContext ctx, IWebHostEnvironment hosting)
        {
            _ctx = ctx;
            _hosting = hosting;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            if (!_ctx.Users.Any()) 
            {
                _ctx.Users.AddRange(
                    new List<User>()
                    {
                        new User() { FirstName = "Mark", MidName = "J", LastName = "Lavin", DOB = new DateTime(day:11, month:12, year:1996) },
                        new User() { FirstName = "Jogh", MidName = "Frank", LastName = "Doe", DOB = new DateTime(day:1, month:1, year:1980) },
                        new User() { FirstName = "Jane", MidName = "Frank", LastName = "Doe", DOB = new DateTime(day:1, month:1, year:1986) },
                        new User() { FirstName = "Mark", MidName = "Frank", LastName = "Smith", DOB = new DateTime(day:1, month:1, year:1972) },
                        new User() { FirstName = "Mary", MidName = "Frank", LastName = "Smith", DOB = new DateTime(day:18, month:2, year:1975) },
                    }
                );
                _ctx.SaveChanges();

            }

        }
    }
}
