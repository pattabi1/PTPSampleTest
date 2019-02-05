using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace PTPTestPortal.Models
{
    public class NEWs
    {
        [Key]
        public int NewsID { get; set; }

        [Column(TypeName = "char(3)")]
        [DisplayName("WebSection ID")]
        public string webSectionID { get; set; }

        [DisplayName("Upload ID")]
        public int UploadID { get; set; }

        [StringLength(150)]
        public string Title { get; set; }

        [StringLength(4000)]
        public string Body { get; set; }

        [StringLength(4000)]
        public string Caption { get; set; }

        public int sOrder { get; set; }

        [Column(TypeName = "char(3)")]
        public string featuredCode { get; set; }

        [Column(TypeName = "Datetime")]
        [DisplayName("Update Date")]
        public DateTime newsDate { get; set; }

        [Column(TypeName = "Datetime")]
        [DisplayName("Start Date")]
        public DateTime startOn { get; set; }

        [Column(TypeName = "Datetime")]
        [DisplayName("End Date")]
        public DateTime endOn { get; set; }

        public int isGlobal { get; set; }

        public NEWs()
        {
            this.webSectionID = "res";

        }
    }
}
