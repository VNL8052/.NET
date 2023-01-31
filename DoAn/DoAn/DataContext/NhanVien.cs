namespace DoAn.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            HoaDon = new HashSet<HoaDon>();
        }

        [Key]
        [StringLength(10)]
        public string MaNV { get; set; }

        [StringLength(500)]
        public string TenNV { get; set; }

        public DateTime? NgaySinh { get; set; }

        [StringLength(500)]
        public string DiaChi { get; set; }

        public int? SDT { get; set; }

        [StringLength(500)]
        public string Email { get; set; }

        [StringLength(500)]
        public string TaiKhoan { get; set; }

        [StringLength(500)]
        public string MatKhau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDon { get; set; }
    }
}
