namespace StudentSIS.API.Contracts
{
    public interface IBaseRepository <Entity> where Entity : class
    {
        public Entity GetById (int id);
        public IEnumerable<Entity> GetAll();

        public void Update(Entity entity);

        public void Add(Entity entity);
    }
}
