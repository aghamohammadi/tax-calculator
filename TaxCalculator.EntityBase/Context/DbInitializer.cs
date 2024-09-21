using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace TaxCalculator.EntityBase.Context
{
    public class DbInitializer
    {
        private readonly TaxCalculatorDbContext _context;
        private readonly ModelBuilder _modelBuilder;

        
        public DbInitializer(TaxCalculatorDbContext context)
        {
            _context = context;
        }

        //public void Seed()
        //{

        //    var currentDirectory = Directory.GetCurrentDirectory();
        //    var directoryInfo = new DirectoryInfo(currentDirectory);
        //    var parentDirectory = directoryInfo.Parent.Parent.Parent.Parent;

        //    string filePathSubscription = Path.Combine(parentDirectory.FullName, "TaxCalculator.EntityBase", "SeedData", "subscriptions.csv");

        //    using (var reader = new StreamReader(filePathSubscription))
        //    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        //    {
        //        csv.Context.RegisterClassMap<SubscriptionMap>();

        //        var records = csv.GetRecords<Subscription>().ToList();

        //        _context.Subscription.AddRange(records);
        //        _context.SaveChanges();
        //    }



        //    //modelBuilder.Entity<User>().HasData(
        //    //       new User() { Id = 1.... },
        //    //       new User() { Id = 2.... },


        //    //);
        //}

        public async Task SeedAsync()
        {

            var currentDirectory = Directory.GetCurrentDirectory();
            var directoryInfo = new DirectoryInfo(currentDirectory);
            var parentDirectory = directoryInfo.Parent.Parent.Parent.Parent;

            string filePathSubscription = Path.Combine(parentDirectory.FullName, "TaxCalculator.EntityBase", "SeedData", "subscriptions.csv");

            using (var reader = new StreamReader(filePathSubscription))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<SubscriptionMap>();
                var records = new List<Subscription>();

                await foreach (var record in csv.GetRecordsAsync<Subscription>())
                {
                    records.Add(record);
                }

                //var records = csv.GetRecords<Subscription>().ToList();
                //records.ForEach(a => a.Id = Guid.NewGuid());
                //_modelBuilder.Entity<Subscription>().HasData(records);
                await _context.Subscription.AddRangeAsync(records);
                await _context.SaveChangesAsync();

            }




        }
    }


}
