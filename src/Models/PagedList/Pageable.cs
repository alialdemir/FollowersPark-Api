using Newtonsoft.Json;
using System.Collections.Generic;

namespace FollowersPark.Models.PagedList
{
    public class Pageable
    {
        private int? _pageNumber = 1;

        private int? _pageSize = 10;

        [JsonIgnore]
        public int Offset
        {
            get
            {
                return PageSize.Value * (PageNumber.Value - 1);
            }
        }

        /// <summary>
        /// Sayfa numarası
        /// </summary>
        public int? PageNumber
        {
            get { return _pageNumber; }
            set { if (value > 0) _pageNumber = value; }
        }

        /// <summary>
        /// Sayfa başına gösterilen kayıt sayısı default 10
        /// </summary>
        public int? PageSize
        {
            get { return _pageSize; }
            set { if (value > 0) _pageSize = value; }
        }

        public IDictionary<string, object> Properties { get; set; }

        public override string ToString()
        {
            return $"?{nameof(PageSize)}={PageSize}&{nameof(PageNumber)}={PageNumber}";
        }
    }
}