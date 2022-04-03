//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IndieGames
{
    using System;
    using System.Collections.Generic;
    
    public partial class Game
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Game()
        {
            this.ClientsAndGames = new HashSet<ClientsAndGame>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> StudioId { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string Image { get; set; }
        public Nullable<int> Cost { get; set; }
        public string Description { get; set; }
        public string Trailer { get; set; }
        public string MagnetUri { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientsAndGame> ClientsAndGames { get; set; }
        public virtual Studio Studio { get; set; }
    }
}
