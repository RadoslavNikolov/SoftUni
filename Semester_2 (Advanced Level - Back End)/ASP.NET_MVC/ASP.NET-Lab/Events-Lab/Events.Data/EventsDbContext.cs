namespace Events.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class EventsDbContext : IdentityDbContext<User>
    {
        public EventsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static EventsDbContext Create()
        {
            return new EventsDbContext();
        }

        public virtual IDbSet<Event> Events { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }
    }

}