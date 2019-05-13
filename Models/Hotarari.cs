using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WebSalt.Models
{
    [Serializable]
    [DataContract(IsReference = true)]
    public class Hotarari : EntityBase
    {
        [DataMember]
        [Display(Name = "id")]
        public Int32 id { get; set; }

        [DataMember]
        [Display(Name = "sectia")]
        public String sectia { get; set; }

        [DataMember]
        [Display(Name = "completul")]
        public String completul { get; set; }

        [DataMember]
        [Display(Name = "nr_ordine")]
        public Int32 nr_ordine { get; set; }

        [DataMember]
        [Display(Name = "numar_national")]
        public String numar_national { get; set; }

        [DataMember]
        [Display(Name = "obiect_dosar")]
        public String obiect_dosar { get; set; }

        [DataMember]
        [Display(Name = "stadiu_procesual")]
        public String stadiu_procesual { get; set; }

        [DataMember]
        [Display(Name = "parti")]
        public String parti { get; set; }

        [DataMember]
        [Display(Name = "status_sedinta")]
        public String status_sedinta { get; set; }

        [DataMember]
        [Display(Name = "sala_sedinta")]
        public string sala_sedinta { get; set; }

        [DataMember]
        [Display(Name = "data_sedinta")]
        public DateTime data_sedinta { get; set; }

        [DataMember]
        [Display(Name = "ora_complet")]
        public DateTime ora_complet { get; set; }

        [DataMember]
        [Display(Name = "termen_acordat")]
        public String termen_acordat { get; set; }

        [DataMember]
        [Display(Name = "pronuntare_sedinta")]
        public String pronuntare_sedinta { get; set; }

        [DataMember]
        [Display(Name = "obiect_sedinta")]
        public String obiect_sedinta { get; set; }

        [DataMember]
        [Display(Name = "complet_activ_sedinta")]
        public Int32 complet_activ_sedinta { get; set; }

        [DataMember]
        [Display(Name = "complet_suspendat_sedinta")]
        public Int32 complet_suspendat_sedinta { get; set; }

        [DataMember]
        [Display(Name = "interval_orar_suspendare")]
        public String interval_orar_suspendare { get; set; }

        [DataMember]
        [Display(Name = "nr_ordine_text")]
        public String nr_ordine_text { get; set; }
    }

}