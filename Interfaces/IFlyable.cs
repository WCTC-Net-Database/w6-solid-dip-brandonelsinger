namespace W6_assignment_template.Interfaces
{
    // IFlyable defines a contract for characters or objects that can perform a flying action.
    // This interface allows any class (such as Ghost) to implement flying behavior,
    // supporting polymorphism and flexible game logic.
    public interface IFlyable
    {
        // Performs the flying action for the implementing class.
        public void Fly();
    }
}