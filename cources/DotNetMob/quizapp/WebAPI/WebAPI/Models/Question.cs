namespace WebAPI.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Question")]
    public partial class Question
    {
        [Key]
        public int QnID { get; set; }

        [StringLength(250)]
        public string Qn { get; set; }

        [StringLength(50)]
        public string ImageName { get; set; }

        [StringLength(50)]
        public string Option1 { get; set; }

        [StringLength(50)]
        public string Option2 { get; set; }

        [StringLength(50)]
        public string Option3 { get; set; }

        [StringLength(50)]
        public string Option4 { get; set; }

        public int? Answer { get; set; }
    }
}
