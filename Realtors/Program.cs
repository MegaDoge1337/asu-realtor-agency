using System;
using System.Collections.Generic;
using System.Linq;
using Realtors.Entities;

namespace Realtors
{
    public class Program
    {
        private static int GetMonthDateDifference(DateTime since, DateTime before)
        {
            if (before < since)
            {
                return -1;
            }

            var monthes = 0;

            while ((before.Month < since.Month) && (before.Year > since.Year))
            {
                since = since.AddMonths(1);
                monthes++;
            }

            return monthes;
        }

        private enum RealEstateTypes
        {
            Appartaments = 1,
            Flat = 2,
            _ = 3
        }

        /* Const values of queries */
        private const int _roomsCount = 2;
        private const int _floor = 2;
        private const int _criteriaId = 5;
        private const int _realEstateAppartamentsType = ((int)RealEstateTypes.Appartaments);
        private const int _realEstateFlatType = ((int)RealEstateTypes.Flat);
        private const int _percentageDifference = 50;
        private const int _amountDifference = 100000;

        public static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("Execute faield: Method not specified");
                    return;
                }

                switch (args[0])
                {
                    case "GetRealEstateInAmountRangeByDisctrict":
                        /* Execute case like "Realtors.exe GetRealEstateInAmountRangeByDisctrict Iowa 1000000 5000000" */
                        var c1District = args[1];
                        var c1MinAmount = Convert.ToInt32(args[2]);
                        var c1MaxAmount = Convert.ToInt32(args[3]);
                        Console.WriteLine("Try to find real estate...\n");
                        GetRealEstateInAmountRangeByDisctrict(c1District, c1MinAmount, c1MaxAmount);
                        break;
                    case "GetRealtorNameBySaledRealEstate":
                        /* Execute case like "Realtors.exe GetRealtorNameBySaledRealEstate" */
                        Console.WriteLine("Rooms count default const: " + _roomsCount.ToString());
                        Console.WriteLine("Try to find realtors...\n");
                        GetRealtorNameBySaledRealEstate();
                        break;
                    case "GetAmountDifferenceBySaledRealEstate":
                        /* Execute case like "Realtors.exe GetAmountDifferenceBySaledRealEstate" */
                        Console.WriteLine("Floor default const: " + _floor.ToString());
                        Console.WriteLine("Try to find real estate...\n");
                        GetAmountDifferenceBySaledRealEstate();
                        break;
                    case "GetRealEstateAmountSumByDistrict":
                        /* Execute case like "Realtors.exe GetRealEstateAmountSumByDistrict Vermont" */
                        var c4District = args[1];
                        Console.WriteLine("Rooms count default const: " + _roomsCount.ToString());
                        Console.WriteLine("Try to calculate sum...\n");
                        GetRealEstateAmountSumByDistrict(c4District);
                        break;
                    case "GetMaxAndMinSaleAmountByRealtor":
                        /* Execute case like "Realtors.exe GetMaxAndMinSaleAmountByRealtor Nietzsche" */
                        var c5LastName = args[1];
                        Console.WriteLine("Try to find max and min amounts...\n");
                        GetMaxAndMinSaleAmountByRealtor(c5LastName);
                        break;
                    case "GetAverangeEvaluationByDistrict":
                        /* Execute case like "Realtors.exe GetAverangeEvaluationByDistrict Alabama" */
                        var c6District = args[1];
                        Console.WriteLine("Try to find averange evaluation...\n");
                        GetAverangeEvaluationByDistrict(c6District);
                        break;
                    case "GetSecondFloorRealEstateCountByDictricts":
                        /* Execute case like "Realtors.exe GetSecondFloorRealEstateCountByDictricts" */
                        Console.WriteLine("Floor default const: " + _floor.ToString());
                        Console.WriteLine("Try to find real estate...\n");
                        GetSecondFloorRealEstateCountByDictricts();
                        break;
                    case "GetAverangeCriteriaEvaluationByRealtor":
                        /* Execute case like "Realtors.exe GetAverangeCriteriaEvaluationByRealtor Kerluke" */
                        var c8LastName = args[1];
                        Console.WriteLine("Real estate type default const: " + _realEstateAppartamentsType.ToString());
                        Console.WriteLine("Evaluation criteria default const: " + _criteriaId.ToString());
                        Console.WriteLine("Try to find averange evaluation...\n");
                        GetAverangeCriteriaEvaluationByRealtor(c8LastName);
                        break;
                    case "GetAverangeAmountOfOneRealEstateSqMeterSaledBetween":
                        /* Execute case like "Realtors.exe GetAverangeAmountOfOneRealEstateSqMeterSaledBetween 01.04.2021 01.04.2022" */
                        var c9Since = DateTime.Parse(args[1]);
                        var c9Before = DateTime.Parse(args[2]);
                        Console.WriteLine("Real estate type default const: " + _realEstateFlatType.ToString());
                        Console.WriteLine("Try to find averange amount...\n");
                        GetAverangeAmountOfOneRealEstateSqMeterSaledBetween(c9Since, c9Before);
                        break;
                    case "GetRealtorBounty":
                        /* Execute case like "Realtors.exe GetRealtorBounty Kerluke" */
                        var c10LastName = args[1];
                        Console.WriteLine("Try to calculate realtor bounty...\n");
                        GetRealtorBounty(c10LastName);
                        break;
                    case "GetCountOfRealtorsSales":
                        /* Execute case like "Realtors.exe GetCountOfRealtorsSales" */
                        Console.WriteLine("Try to count realtors sales...\n");
                        GetCountOfRealtorsSales();
                        break;
                    case "GetRealEstateAverangeAmountByMaterials":
                        /* Execute case like "Realtors.exe GetRealEstateAverangeAmountByMaterials" */
                        Console.WriteLine("Try to calculate averange real estate amount...\n");
                        GetRealEstateAverangeAmountByMaterials();
                        break;
                    case "GetMostExpensiveRealEstateByDistricts":
                        /* Execute case like "Realtors.exe GetMostExpensiveRealEstateByDistricts" */
                        Console.WriteLine("Try to order real estate...\n");
                        GetMostExpensiveRealEstateByDistricts();
                        break;
                    case "GetNotSoldRealEstateByDistrict":
                        /* Execute case like "Realtors.exe GetNotSoldRealEstateByDistrict Florida" */
                        var c14District = args[1];
                        Console.WriteLine("Try to get real estate addresses...\n");
                        GetNotSoldRealEstateByDistrict(c14District);
                        break;
                    case "GetRealEstateInDistrictByDifferencePercent":
                        /* Execute case like "Realtors.exe GetRealEstateInDistrictByDifferencePercent Florida" */
                        var c15District = args[1];
                        Console.WriteLine("Try to calculate percentage difference...\n");
                        GetRealEstateInDistrictByDifferencePercent(c15District);
                        break;
                    case "GetRealEstateAmountDifferenceByRealtor":
                        /* Execute case like "Realtors.exe GetRealEstateAmountDifferenceByRealtor Kerluke" */
                        var c16LastName = args[1];
                        Console.WriteLine("Try to calculate amount difference...\n");
                        GetRealEstateAmountDifferenceByRealtor(c16LastName);
                        break;
                    case "GetRealEstateAmountDifferenceByRealtorAndYear":
                        /* Execute case like "Realtors.exe GetRealEstateAmountDifferenceByRealtorAndYear Kerluke 2021" */
                        var c17LastName = args[1];
                        var c17Year = Convert.ToInt32(args[2]);
                        Console.WriteLine("Try to calculate percentage difference...\n");
                        GetRealEstateAmountDifferenceByRealtorAndYear(c17LastName, c17Year);
                        break;
                    case "GetCheapestSqMeterRealEstateOfDistrict":
                        /* Execute case like "Realtors.exe GetCheapestSqMeterRealEstateOfDistrict" */
                        Console.WriteLine("Try to calculate averange square meter amounts...\n");
                        GetCheapestSqMeterRealEstateOfDistrict();
                        break;
                    case "GetRealtorsWheSaledNothingInCurrentYear":
                        /* Execute case like "Realtors.exe GetRealtorsWheSaledNothingInCurrentYear" */
                        Console.WriteLine("Try to find realtors with no sales...\n");
                        GetRealtorsWheSaledNothingInCurrentYear();
                        break;
                    case "GetCheapestSqMeterRealEstateOfDistrictWhichRecentlyPosted":
                        /* Execute case like "Realtors.exe GetCheapestSqMeterRealEstateOfDistrictWhichRecentlyPosted" */
                        Console.WriteLine("Try to calculate averange square meter amounts...\n");
                        GetCheapestSqMeterRealEstateOfDistrictWhichRecentlyPosted();
                        break;
                    default:
                        Console.WriteLine("Execute failed: Method '" + args[0] + "' not found");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Execute failed: " + ex.Message);
            }
        }

        public static void GetRealEstateInAmountRangeByDisctrict(string district, int minAmount, int maxAmount)
        {
            using (var context = new RealtorAgencyDbContext())
            {
                foreach (var realEstate in context.RealEstate.Where(r => r.District.Title == district
                                                                    && r.Amount >= minAmount
                                                                    && r.Amount <= maxAmount)
                )
                {
                    Console.WriteLine(realEstate.Address
                        + ", " + realEstate.Square.ToString()
                        + ", " + realEstate.Floor.ToString());
                }
            }
        }

        public static void GetRealtorNameBySaledRealEstate()
        {
            using (var context = new RealtorAgencyDbContext())
            {
                var people = new List<Realtor>();
                foreach (var sale in context.Sales.Include("Realtor").Where(s => s.RealEstate.RoomsCount == _roomsCount))
                {
                    if (people.Contains(sale.Realtor))
                    {
                        continue;
                    }

                    Console.WriteLine(sale.Realtor.LastName + " " + sale.Realtor.FirstName + " " + sale.Realtor.MiddleName);
                    people.Add(sale.Realtor);
                }
            }
        }

        public static void GetAmountDifferenceBySaledRealEstate()
        {
            using (var context = new RealtorAgencyDbContext())
            {
                foreach (var sale in context
                    .Sales
                    .Include("RealEstate")
                    .Include("Realtor")
                    .Where(s => s.RealEstate.Floor == _floor)
                )
                {
                    var difference = Math.Abs(sale.Amount - sale.RealEstate.Amount);
                    Console.WriteLine(sale.RealEstate.Address + " "
                        + difference.ToString() + " "
                        + sale.Realtor.LastName + " "
                        + sale.Realtor.FirstName + " "
                        + sale.Realtor.MiddleName);
                }
            }
        }

        public static void GetRealEstateAmountSumByDistrict(string district)
        {
            using (var context = new RealtorAgencyDbContext())
            {
                int sum = 0;
                foreach (var realEstate in context
                    .RealEstate
                    .Include("District")
                    .Where(r => r.RoomsCount == _roomsCount && r.District.Title == district)
                )
                {
                    sum += realEstate.Amount;
                }
                Console.WriteLine(sum);
            }
        }

        public static void GetMaxAndMinSaleAmountByRealtor(string lastName)
        {
            using (var context = new RealtorAgencyDbContext())
            {
                var sales = context.Sales.Include("Realtor").Where(s => s.Realtor.LastName == lastName);
                Console.WriteLine(sales.Max(s => s.Amount).ToString() + " " + sales.Min(s => s.Amount).ToString());
            }
        }

        public static void GetAverangeEvaluationByDistrict(string district)
        {
            using (var context = new RealtorAgencyDbContext())
            {
                var averange = context
                    .Evaluations
                    .Include("RealEstate")
                    .Where(e => e.RealEstate.District.Title == district)
                    .Average(e => e.Rating);
                Console.WriteLine(averange);
            }
        }

        public static void GetSecondFloorRealEstateCountByDictricts()
        {
            using (var context = new RealtorAgencyDbContext())
            {
                foreach (var district in context.Districts)
                {
                    var realEstateCount = context
                        .RealEstate.Include("District")
                        .Where(r => r.District.Id == district.Id && r.Floor == _floor)
                        .Count();
                    Console.WriteLine(district.Title + " " + realEstateCount.ToString());
                }
            }
        }

        public static void GetAverangeCriteriaEvaluationByRealtor(string lastName)
        {
            using (var context = new RealtorAgencyDbContext())
            {
                var sales = context
                    .Sales
                    .Include("RealEstate")
                    .Include("Realtor")
                    .Where(s => s.Realtor.LastName == lastName && s.RealEstate.Type == _realEstateAppartamentsType);

                var evaluations = context
                    .Evaluations
                    .Where(e => sales.Any(s => s.RealEstateId == e.RealEstateId) && e.EvaluationCriteriaId == _criteriaId);

                if (evaluations.Count() == 0)
                {
                    Console.WriteLine("Nothing found");
                    return;
                }

                Console.WriteLine(evaluations.Average(e => e.Rating));
            }
        }

        public static void GetAverangeAmountOfOneRealEstateSqMeterSaledBetween(DateTime since, DateTime before)
        {
            using (var context = new RealtorAgencyDbContext())
            {
                var sales = context
                    .Sales
                    .Include("RealEstate")
                    .Include("Realtor")
                    .Where(s => s.RealEstate.Type == _realEstateFlatType)
                    .Where(s => s.Date >= since)
                    .Where(s => s.Date <= before);


                if (sales.Count() == 0)
                {
                    Console.WriteLine("Nothing found");
                    return;
                }

                Console.WriteLine(sales.Average(s => (s.Amount / s.RealEstate.Square)));
            }
        }

        public static void GetRealtorBounty(string lastName)
        {
            using (var context = new RealtorAgencyDbContext())
            {
                var realtor = context.Realtors.Where(r => r.LastName == lastName).FirstOrDefault();

                if (realtor != null)
                {
                    var sales = context.Sales.Include("Realtor").Where(s => s.RealtorId == realtor.Id);
                    var salesCount = sales.Count();
                    var salesAmountSum = sales.Sum(s => s.Amount);

                    var bounty = (salesCount * salesAmountSum * 0.05) - ((salesCount * salesAmountSum * 0.05) * 0.13);

                    var result = string.Format("{0} {1} {2} - {3}", realtor.LastName, realtor.FirstName, realtor.MiddleName, bounty);
                    Console.WriteLine(result);
                    return;
                }
                Console.WriteLine("Realtor not found");
            }
        }

        public static void GetCountOfRealtorsSales()
        {
            using (var context = new RealtorAgencyDbContext())
            {
                var sales = context
                    .Sales
                    .Include("Realtor")
                    .Include("RealEstate")
                    .Where(s => s.RealEstate.Type == _realEstateFlatType);

                foreach (var realtor in context.Realtors)
                {
                    Console.WriteLine(string.Format("{0} {1} {2} - {3}",
                        realtor.LastName,
                        realtor.FirstName,
                        realtor.MiddleName,
                        sales.Where(s => s.RealtorId == realtor.Id).Count()
                    ));
                }
            }
        }

        public static void GetRealEstateAverangeAmountByMaterials()
        {
            using (var context = new RealtorAgencyDbContext())
            {
                var materials = context.BuildingMaterials;

                foreach (var material in materials)
                {
                    var realEstate = context
                        .RealEstate
                        .Where(r => r.Floor == _floor)
                        .Where(r => r.BuildingMaterialId == material.Id);

                    var averange = 0.0;
                    if (realEstate.Count() != 0)
                    {
                        averange = realEstate.Average(r => r.Amount);
                    }

                    Console.WriteLine(material.Title + " " + averange.ToString());
                }
            }
        }

        public static void GetMostExpensiveRealEstateByDistricts()
        {
            using (var context = new RealtorAgencyDbContext())
            {
                foreach (var district in context.Districts)
                {
                    var realEstate = context
                        .RealEstate
                        .Include("District")
                        .Where(r => r.DistrictId == district.Id)
                        .OrderByDescending(r => r.Amount)
                        .ThenBy(r => r.Floor)
                        .Take(3);

                    foreach (var singleRealEstate in realEstate)
                    {
                        var row = string.Format("{0} - {1} {2} {3}",
                            singleRealEstate.District.Title,
                            singleRealEstate.Address,
                            singleRealEstate.Amount,
                            singleRealEstate.Floor);
                        Console.WriteLine(row);
                    }
                }
            }
        }

        public static void GetNotSoldRealEstateByDistrict(string district)
        {
            using (var context = new RealtorAgencyDbContext())
            {
                foreach (var realEstate in context
                    .RealEstate
                    .Include("District")
                    .Where(r => r.District.Title == district
                    && r.Status == 1)
                )
                {
                    Console.WriteLine(realEstate.Address);
                }
            }
        }

        public static void GetRealEstateInDistrictByDifferencePercent(string district)
        {
            using (var context = new RealtorAgencyDbContext())
            {
                var districtEntity = context.Districts.Where(d => d.Title == district).FirstOrDefault();
                foreach (var realEstate in context.RealEstate.Where(r => r.DistrictId == districtEntity.Id && r.Status == 0))
                {
                    var requestAmount = realEstate.Amount;
                    var saleAmount = context.Sales.Where(s => s.RealEstateId == realEstate.Id).FirstOrDefault().Amount;

                    var percentageDifference = (requestAmount * 100) / saleAmount;
                    if (percentageDifference <= _percentageDifference)
                    {
                        Console.WriteLine(realEstate.Address + " " + districtEntity.Title);
                    }
                }
            }
        }

        public static void GetRealEstateAmountDifferenceByRealtor(string lastName)
        {
            using (var context = new RealtorAgencyDbContext())
            {
                var realtor = context.Realtors.Where(r => r.LastName == lastName).FirstOrDefault();
                foreach (var sale in context.Sales.Include("RealEstate").Where(s => s.RealtorId == realtor.Id))
                {
                    var requestAmount = sale.RealEstate.Amount;
                    var saleAmount = sale.Amount;

                    if (Math.Abs(requestAmount - saleAmount) >= _amountDifference)
                    {
                        var district = context.Districts.Where(d => d.Id == sale.RealEstate.DistrictId).FirstOrDefault();
                        Console.WriteLine(sale.RealEstate.Address + " " + district.Title);
                    }
                }
            }
        }

        public static void GetRealEstateAmountDifferenceByRealtorAndYear(string lastName, int year)
        {
            using (var context = new RealtorAgencyDbContext())
            {
                var realtor = context.Realtors.Where(r => r.LastName == lastName).FirstOrDefault();
                foreach (var sale in context
                    .Sales
                    .Include("RealEstate")
                    .Where(s => s.RealtorId == realtor.Id)
                    .Where(s => s.Date.Year == year)
                )
                {
                    var requestAmount = sale.RealEstate.Amount;
                    var saleAmount = sale.Amount;

                    var percentageDifference = (requestAmount * 100) / saleAmount;

                    Console.WriteLine(sale.RealEstate.Address + " " + percentageDifference.ToString());
                }
            }
        }

        public static void GetCheapestSqMeterRealEstateOfDistrict()
        {
            using (var context = new RealtorAgencyDbContext())
            {
                foreach (var district in context.Districts)
                {
                    if (context.RealEstate.Where(r => r.DistrictId == district.Id).Count() == 0)
                    {
                        continue;
                    }

                    var districtAverangeSqMeterAmount = Convert.ToInt32(
                        context
                        .RealEstate
                        .Where(r => r.DistrictId == district.Id)
                        .Average(r => (r.Amount / r.Square))
                    );
                    foreach (var realEstate in context.RealEstate.Where(r => r.DistrictId == district.Id))
                    {
                        var realEstateAverangeSqMeterAmount = realEstate.Amount / realEstate.Square;
                        if (realEstateAverangeSqMeterAmount <= districtAverangeSqMeterAmount)
                        {
                            Console.WriteLine(realEstate.Address);
                        }
                    }
                }
            }
        }

        public static void GetRealtorsWheSaledNothingInCurrentYear()
        {
            using (var context = new RealtorAgencyDbContext())
            {
                foreach (var realtor in context.Realtors)
                {
                    if (!context.Sales.Where(s => s.Date.Year == DateTime.Now.Year).Any(s => s.RealtorId == realtor.Id))
                    {
                        Console.WriteLine(realtor.LastName + " " + realtor.FirstName + " " + realtor.MiddleName);
                    }
                }
            }
        }

        public static void GetCheapestSqMeterRealEstateOfDistrictWhichRecentlyPosted()
        {
            using (var context = new RealtorAgencyDbContext())
            {
                foreach (var district in context.Districts)
                {
                    if (context.RealEstate.Where(r => r.DistrictId == district.Id).Count() == 0)
                    {
                        continue;
                    }

                    var districtAverangeSqMeterAmount = Convert.ToInt32(
                        context
                        .RealEstate
                        .Where(r => r.DistrictId == district.Id)
                        .Average(r => (r.Amount / r.Square))
                    );
                    foreach (var realEstate in context.RealEstate.Where(r => r.DistrictId == district.Id))
                    {
                        var realEstateAverangeSqMeterAmount = realEstate.Amount / realEstate.Square;
                        if (realEstateAverangeSqMeterAmount <= districtAverangeSqMeterAmount
                            && GetMonthDateDifference(realEstate.Date, DateTime.Now) < 4)
                        {
                            Console.WriteLine(realEstate.Address);
                        }
                    }
                }
            }
        }
    }
}
