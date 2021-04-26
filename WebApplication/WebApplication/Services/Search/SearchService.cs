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


        public SearchService( MyDBContext context)
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
            var data_1 = from st in _context.ShareTrip
                         join b in _context.Booking on st.BookingId equals b.Id
                         join d in _context.Driver on b.IdDriver equals d.Id
                         join c in _context.Car on d.IdCar equals c.Id
                         select new { st, b, d, c };

            var data_2 = _context.ShareTrip.ToList();
            var data_3 = _context.Booking.ToList();

            List<SaveValue> data_4 = new List<SaveValue>();

            foreach (var item_1 in data_2)
            {
                var value_member = 0;
                int? value_id = 0;
                foreach (var item_2 in data_3)
                {
                    if (item_1.BookingId != null)
                    {
                        if (item_2.Id == item_1.BookingId)
                        {
                            value_member = value_member + item_2.Member;
                            value_id = item_1.BookingId;
                        }
                    }
                }
                if (value_id != 0)
                {
                    data_4.Add(new SaveValue() { id = value_id, count = value_member });
                }
            }
            //Số lương member của một chuyến
            var result_1 = data_4;
            List<SuitableCarModelView> data_6 = new List<SuitableCarModelView>();
            foreach (var item_3 in result_1)
            {
                var data_5 = data_1.Select(x => new SuitableCarModelView()
                {
                    Id = item_3.id,
                    address_from = x.b.EndFrom,
                    address_to = x.st.FromTo,
                    date = x.st.Date,
                    member = Int32.Parse(x.c.Type) - item_3.count,
                }).Where(x => x.Id == item_3.id).FirstOrDefault();

                data_6.Add(data_5);
            };
            
            if(model.address_from != null)
            {
                data_6 = data_6.Where(x => x.address_from == model.address_from).ToList();
            }
            if (model.address_to != null)
            {
                data_6 = data_6.Where(x => x.address_to == model.address_to).ToList();
            }
            if (model.date!= null)
            {
                data_6 = data_6.Where(x => x.date == model.date).ToList();
            }
            if (model.member != null)
            {
                data_6 = data_6.Where(x => x.member == model.member).ToList();
            }

            return data_6;
        }
    }
}
