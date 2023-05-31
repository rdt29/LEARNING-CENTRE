using LearningCentre.Core.Contract;
using LearningCentre.Core.Services;
using LearningCentre.Core.Services.Helper.Implementation;
using LearningCentre.Core.Services.Helper.Interface;
using LearningCentre.Infra.Contract;
using LearningCentre.Infra.Repo;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LEARNING_CENTRE_PROJECT.Configuration
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserServices>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddTransient<IGenerateToken, GenerateToken>();

            services.AddTransient<ITechnologyRepository, TechnologyRepository>();
            services.AddTransient<ITechnologyServices, TechnologyServices>();

            services.AddTransient<ITaskEvaluationRepository,TaskEvaluationRepository>();
            services.AddTransient<ITaskEvaluationServices, TaskEvaluationServices>();



            services.AddTransient<IRoleServices, RoleServices>();
            services.AddTransient<IRoleRepository, RoleRepository>();

            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<ITaskServices, TaskServices>();


            services.AddTransient<IAssignTaskRepository, AssignTaskRespository>();
            services.AddTransient<IAssignTaskServices, AssignTaskServices>();


            services.AddTransient<ISubmittedTaskRepository, SubmittedTaskRepo>();
            services.AddTransient<ISubmittedTaskServices, SubmittedTaskServices>();

            services.AddTransient<ICloudnary,CloudinaryServices>();
            services.AddTransient<IUserMapping, UserMapping>();

            services.AddScoped<IMailServices, MailServices>();



        }
    }
}
