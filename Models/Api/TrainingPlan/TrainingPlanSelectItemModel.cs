namespace GymApp.Models.Api.TrainingPlan
{
    public class TrainingPlanSelectItemModel<T>
    {
        public TrainingPlanSelectItemModel()
        {
        }

        public TrainingPlanSelectItemModel(T key, string value)
        {
            Key = key;
            Value = value;
        }

        public T Key { get; set; }
        public string Value { get; set; }
    }
}
