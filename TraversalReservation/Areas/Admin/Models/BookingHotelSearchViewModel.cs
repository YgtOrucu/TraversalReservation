using Newtonsoft.Json;

namespace TraversalReservation.Areas.Admin.Models
{
    public class BookingHotelSearchViewModel
    {
        [JsonProperty("results")]
        public List<Result> Results { get; set; }

        [JsonProperty("total_count")]
        public int TotalCount { get; set; }

        public class Map_Bounding_Box
        {
            public float sw_lat { get; set; }
            public float ne_lat { get; set; }
            public float ne_long { get; set; }
            public float sw_long { get; set; }
        }

        public class Room_Distribution
        {
            public int[] children { get; set; }
            public string adults { get; set; }
        }

        public class Sort
        {
            public string name { get; set; }
            public string id { get; set; }
        }

        public class Result
        {
            [JsonProperty("hotel_id")]
            public int HotelId { get; set; }

            [JsonProperty("hotel_name")]
            public string HotelName { get; set; }

            [JsonProperty("hotel_name_trans")]
            public string HotelNameTrans { get; set; }

            [JsonProperty("city")]
            public string City { get; set; }

            [JsonProperty("countrycode")]
            public string CountryCode { get; set; }

            [JsonProperty("review_score")]
            public float? ReviewScore { get; set; }

            [JsonProperty("review_score_word")]
            public string ReviewScoreWord { get; set; }

            [JsonProperty("review_nr")]
            public int? ReviewNr { get; set; }

            [JsonProperty("min_total_price")]
            public decimal? MinTotalPrice { get; set; }

            [JsonProperty("currencycode")]
            public string CurrencyCode { get; set; }

            [JsonProperty("is_free_cancellable")]
            public int IsFreeCancellable { get; set; }

            [JsonProperty("is_genius_deal")]
            public int IsGeniusDeal { get; set; }

            [JsonProperty("is_mobile_deal")]
            public int IsMobileDeal { get; set; }

            [JsonProperty("preferred")]
            public int Preferred { get; set; }

            [JsonProperty("preferred_plus")]
            public int PreferredPlus { get; set; }

            [JsonProperty("class")]
            public int Class { get; set; }

            [JsonProperty("latitude")]
            public float? Latitude { get; set; }

            [JsonProperty("longitude")]
            public float? Longitude { get; set; }

            [JsonProperty("main_photo_url")]
            public string MainPhotoUrl { get; set; }

            [JsonProperty("max_photo_url")]
            public string MaxPhotoUrl { get; set; }

            [JsonProperty("distance_to_cc_formatted")]
            public string DistanceToCenter { get; set; }
        }

        public class Checkin
        {
            public string from { get; set; }
            public string until { get; set; }
        }

        public class Bwallet
        {
            public int hotel_eligibility { get; set; }
        }

        public class Price_Breakdown
        {
            public float all_inclusive_price { get; set; }
            public int has_tax_exceptions { get; set; }
            public int has_fine_print_charges { get; set; }
            public string currency { get; set; }
            public string sum_excluded_raw { get; set; }
            public float gross_price { get; set; }
            public int has_incalculable_charges { get; set; }
        }

        public class Matching_Units_Configuration
        {
            public Matching_Units_Common_Config matching_units_common_config { get; set; }
        }

        public class Matching_Units_Common_Config
        {
            public int unit_type_id { get; set; }
            public string localized_area { get; set; }
        }

        public class Checkout
        {
            public string from { get; set; }
            public string until { get; set; }
        }

        public class Composite_Price_Breakdown
        {
            public Benefit[] benefits { get; set; }
            public int has_long_stays_monthly_rate_price { get; set; }
            public Included_Taxes_And_Charges_Amount included_taxes_and_charges_amount { get; set; }
            public All_Inclusive_Amount all_inclusive_amount { get; set; }
            public Gross_Amount gross_amount { get; set; }
            public int has_long_stays_weekly_rate_price { get; set; }
            public Item[] items { get; set; }
            public Gross_Amount_Hotel_Currency gross_amount_hotel_currency { get; set; }
            public Excluded_Amount excluded_amount { get; set; }
            public Gross_Amount_Per_Night gross_amount_per_night { get; set; }
            public Net_Amount net_amount { get; set; }
            public Product_Price_Breakdowns[] product_price_breakdowns { get; set; }
            public Strikethrough_Amount_Per_Night strikethrough_amount_per_night { get; set; }
            public Discounted_Amount discounted_amount { get; set; }
            public Strikethrough_Amount strikethrough_amount { get; set; }
        }

        public class Included_Taxes_And_Charges_Amount
        {
            public string currency { get; set; }
            public float value { get; set; }
        }

        public class All_Inclusive_Amount
        {
            public float value { get; set; }
            public string currency { get; set; }
        }

        public class Gross_Amount
        {
            public float value { get; set; }
            public string currency { get; set; }
        }

        public class Gross_Amount_Hotel_Currency
        {
            public string currency { get; set; }
            public float value { get; set; }
        }

        public class Excluded_Amount
        {
            public int value { get; set; }
            public string currency { get; set; }
        }

        public class Gross_Amount_Per_Night
        {
            public string currency { get; set; }
            public float value { get; set; }
        }

        public class Net_Amount
        {
            public string currency { get; set; }
            public float value { get; set; }
        }

        public class Strikethrough_Amount_Per_Night
        {
            public string currency { get; set; }
            public float value { get; set; }
        }

        public class Discounted_Amount
        {
            public float value { get; set; }
            public string currency { get; set; }
        }

        public class Strikethrough_Amount
        {
            public string currency { get; set; }
            public float value { get; set; }
        }

        public class Benefit
        {
            public object icon { get; set; }
            public string details { get; set; }
            public string name { get; set; }
            public string identifier { get; set; }
            public string kind { get; set; }
            public string badge_variant { get; set; }
        }

        public class Item
        {
            public Item_Amount item_amount { get; set; }
            public string name { get; set; }
            public string inclusion_type { get; set; }
            public string kind { get; set; }
            public Base _base { get; set; }
            public string details { get; set; }
            public string identifier { get; set; }
        }

        public class Item_Amount
        {
            public float value { get; set; }
            public string currency { get; set; }
        }

        public class Base
        {
            public float base_amount { get; set; }
            public string kind { get; set; }
            public int percentage { get; set; }
        }

        public class Product_Price_Breakdowns
        {
            public Gross_Amount_Hotel_Currency1 gross_amount_hotel_currency { get; set; }
            public Net_Amount1 net_amount { get; set; }
            public Excluded_Amount1 excluded_amount { get; set; }
            public Gross_Amount_Per_Night1 gross_amount_per_night { get; set; }
            public Gross_Amount1 gross_amount { get; set; }
            public Item1[] items { get; set; }
            public int has_long_stays_weekly_rate_price { get; set; }
            public Benefit1[] benefits { get; set; }
            public int has_long_stays_monthly_rate_price { get; set; }
            public Included_Taxes_And_Charges_Amount1 included_taxes_and_charges_amount { get; set; }
            public All_Inclusive_Amount1 all_inclusive_amount { get; set; }
            public Strikethrough_Amount_Per_Night1 strikethrough_amount_per_night { get; set; }
            public Discounted_Amount1 discounted_amount { get; set; }
            public Strikethrough_Amount1 strikethrough_amount { get; set; }
        }

        public class Gross_Amount_Hotel_Currency1
        {
            public float value { get; set; }
            public string currency { get; set; }
        }

        public class Net_Amount1
        {
            public string currency { get; set; }
            public float value { get; set; }
        }

        public class Excluded_Amount1
        {
            public int value { get; set; }
            public string currency { get; set; }
        }

        public class Gross_Amount_Per_Night1
        {
            public float value { get; set; }
            public string currency { get; set; }
        }

        public class Gross_Amount1
        {
            public float value { get; set; }
            public string currency { get; set; }
        }

        public class Included_Taxes_And_Charges_Amount1
        {
            public float value { get; set; }
            public string currency { get; set; }
        }

        public class All_Inclusive_Amount1
        {
            public float value { get; set; }
            public string currency { get; set; }
        }

        public class Strikethrough_Amount_Per_Night1
        {
            public string currency { get; set; }
            public float value { get; set; }
        }

        public class Discounted_Amount1
        {
            public float value { get; set; }
            public string currency { get; set; }
        }

        public class Strikethrough_Amount1
        {
            public float value { get; set; }
            public string currency { get; set; }
        }

        public class Item1
        {
            public Base1 _base { get; set; }
            public string details { get; set; }
            public string name { get; set; }
            public Item_Amount1 item_amount { get; set; }
            public string inclusion_type { get; set; }
            public string kind { get; set; }
            public string identifier { get; set; }
        }

        public class Base1
        {
            public float base_amount { get; set; }
            public string kind { get; set; }
            public int percentage { get; set; }
        }

        public class Item_Amount1
        {
            public float value { get; set; }
            public string currency { get; set; }
        }

        public class Benefit1
        {
            public object icon { get; set; }
            public string details { get; set; }
            public string name { get; set; }
            public string identifier { get; set; }
            public string kind { get; set; }
            public string badge_variant { get; set; }
        }

        public class Booking_Home
        {
            public string group { get; set; }
            public int segment { get; set; }
            public int quality_class { get; set; }
            public string is_single_unit_property { get; set; }
            public int is_booking_home { get; set; }
        }

        public class Badge
        {
            public string id { get; set; }
            public string text { get; set; }
            public string badge_variant { get; set; }
        }

        public class Distance
        {
            public string text { get; set; }
            public string icon_name { get; set; }
            public object icon_set { get; set; }
        }
    }
}
