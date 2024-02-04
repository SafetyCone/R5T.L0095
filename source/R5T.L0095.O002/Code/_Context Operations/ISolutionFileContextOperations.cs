using System;
using System.Threading.Tasks;

using R5T.L0091.T000;
using R5T.L0092.T001;
using R5T.L0095.T000;
using R5T.T0241;


namespace R5T.L0095.O002
{
    [ContextOperationsMarker]
    public partial interface ISolutionFileContextOperations : IContextOperationsMarker
    {
        public Func<TContext, Task> Create_SolutionFile<TContext>(
            IChecked<IFileDoesNotExist> solutionfileDoesNotExist, 
            out IChecked<IFileExists> solutionfileExists)
            where TContext : IHasSolutionFilePath
        {
            solutionfileExists = Checked.Check<IFileExists>();

            return context =>
            {
                return Instances.SolutionFileGenerator.New(
                    context.SolutionFilePath);
            };
        }
    }
}
