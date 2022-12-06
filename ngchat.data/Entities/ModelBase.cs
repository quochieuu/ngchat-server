using ngchat.data.Entities.Common;

namespace ngchat.data.Entities
{
    public class ModelBase : IDateTracking
    {
        public Guid Id { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public Guid? DeletedBy { get; set; }
    }
}
