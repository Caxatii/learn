namespace Mono.Movement
{
    public interface IPhysicMover : IMover 
    {
        public void SetIsGrounded(bool value);
    }
}