using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Controllers;
using WebApplication.Models;
using WebApplication.Models.Publish;

namespace WebApplication.Services.Search
{
    public class SearchService : ISearchService
    {
        private MyDBContext _context;


        public SearchService(MyDBContext context)
        {
            _context = context;
        }
        public class SaveValue
        {
            public int? id;
            public int count;
            public int menber;
        }
        public List<SuitableCarModelView> Search(SuitableCarModelView model)
        {
            var query = _context.ShareTrip.ToList();
            var query_1 = _context.Booking.ToList();

            var query_2 = from d in _context.Driver
                          join c in _context.Car on d.IdCar equals c.Id
                          select new { d, c };
            var query_3 = _context.ShareBooking.ToList();
            var query_4 = _context.Car.ToList();

            var list = new List<SaveValue>();
            var list_1 = new List<SaveValue>();

            //foreach (var item in query)
            //{
            //    foreach (var item_1 in query_3)
            //    {
            //        var list_3 = new List<Booking>();
            //        var value_1 = 0;
            //        if (item_1.IdSharetrip == item.Id)
            //        {
            //            var data = query_1.Where(x => x.Id == item_1.BookingId).First();
            //            list_3.Add(data);
            //        }
            //        foreach (var item_2 in list_3)
            //        {
            //            value_1 = value_1 + item_2.Member;
            //        }
            //        var date_1 = query.Where(x => x.Id == item_1.IdSharetrip).First();
            //        var data_2 = query_2.Where(x => x.d.Id == date_1.DriverId).First();
            //        //var data_3 = query_4.Where(x => x.Id == data_2.)
            //        list.Add(new SaveValue() { id = item_1.IdSharetrip, menber = value_1, count = Int32.Parse(data_2.c.Type) - value_1 });
            //    }
            //}
            //var sum = 0;
            //foreach(var item_3 in lis`t)
            //{
            //    foreach(var item_4 in list)
            //    {
            //        if(item_3.id == item_4.id)
            //        {
                        
            //        }
            //    }
            //}
            //var data_3 = list;

            //foreach (var item_2 in list)
            //{
            //    var value_2 = query_2.Where(x=>x.d.Id == item_2.id).First();
            //    item_2.count = Int16.Parse(value_2.c.Type) - item_2.menber;
            //    list_1.Add(item_2);
            //}

            //var data = list;
            if (model.address_to != null)
            {
                query = query.Where(x => x.FromTo == model.address_to).ToList();
            }
            if (model.address_from != null)
            {
                query = query.Where(x => x.StartTo == model.address_to).ToList();
            }
            if (model.date != null)
            {
                query = query.Where(x => x.Date == model.date).ToList();
            }



            var data_1 = query.Select(x => new SuitableCarModelView()
            {
                address_from = x.FromTo,
                date = x.Date,
                address_to = x.StartTo,
            }).ToList();
            return data_1;
        }
    }
}
