
using Epiphany.Xml;
using System;

namespace Epiphany.Model
{
    public class WorkModel : Entity<int>
    {
        private readonly GoodreadsWork work;

        public WorkModel(GoodreadsWork work)
        {
            if (work == null)
            {
                throw new ArgumentNullException(nameof(work));
            }

            this.work = work;
        }

        public override int Id
        {
            get
            {
                return this.work.Id;
            }
        }

        public BookModel Book
        {
            get
            {
                return new BookModel(work.BestBook);
            }
        }

        public DateTime? OriginalPublicationDate
        {
            get
            {
                int day = Converter.ToInt(work.OriginalPublicationDay, 1);
                int month = Converter.ToInt(work.OriginalPublicationMonth, 1);
                int year = Converter.ToInt(work.OriginalPublicationYear, 0);

                if (year == 0)
                {
                    return null;
                }
                else
                {
                    return new DateTime(day, month, year);
                }
            }
        }

        public double AverageRating
        {
            get
            {
                return Converter.ToDouble(this.work.AverageRating, 0);
            }
        }

        public int RatingsCount
        {
            get
            {
                return Converter.ToInt(this.work.RatingsCount, 0);
            }
        }
    }
}
