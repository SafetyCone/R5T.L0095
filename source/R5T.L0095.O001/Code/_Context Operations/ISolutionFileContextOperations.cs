using System;
using System.Threading.Tasks;

using R5T.L0091.T000;
using R5T.L0092.T001;
using R5T.T0221;
using R5T.T0241;

using R5T.L0095.T000;


namespace R5T.L0095.O001
{
    [ContextOperationsMarker]
    public partial interface ISolutionFileContextOperations : IContextOperationsMarker
    {
        public Func<TContext, Task> Set_SolutionDirectoryPath<TContext>(
            string solutionDirectoryPath,
            out IsSet<IHasSolutionDirectoryPath> solutionDirectoryPathSet)
            where TContext : IWithSolutionDirectoryPath
        {
            return context =>
            {
                context.SolutionDirectoryPath = solutionDirectoryPath;

                return Task.CompletedTask;
            };
        }

        /// <summary>
        /// Set the solution file path using the solution name and the solution directory path.
        /// </summary>
        public Func<TContext, Task> Set_SolutionFilePath<TContext>(
            (IsSet<IHasSolutionName>, IsSet<IHasSolutionDirectoryPath>) propertiesRequired,
            out IsSet<IHasSolutionFilePath> solutionFilePathSet)
            where TContext : IWithSolutionFilePath, IHasSolutionName, IHasSolutionDirectoryPath
        {
            return context =>
            {
                context.SolutionFilePath = Instances.SolutionPathsOperator.Get_SolutionFilePath(
                    context.SolutionDirectoryPath,
                    context.SolutionName);

                return Task.CompletedTask;
            };
        }

        public Func<TContext, Task> Set_SolutionName<TContext>(
            string solutionName,
            out IsSet<IHasSolutionName> solutionFilePathSet)
            where TContext : IWithSolutionName
        {
            return context =>
            {
                context.SolutionName = solutionName;

                return Task.CompletedTask;
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Related: R5T.L0093.O000.IHasFilePathContextOperations.Verify_File_DoesNotExist()
        /// </remarks>
        public Func<TContext, Task> Verify_SolutionFile_DoesNotExist<TContext>(
            IsSet<IHasSolutionFilePath> solutionFilePathRequired,
            out IChecked<IFileDoesNotExist> @checked)
            where TContext : IHasSolutionFilePath
        {
            @checked = Checked.Check<IFileDoesNotExist>();

            return context =>
            {
                var solutionFileExists = Instances.FileSystemOperator.Exists_File(
                context.SolutionFilePath);

                if (solutionFileExists)
                {
                    throw new Exception($"Solution file exists:\n\t{context.SolutionFilePath}");
                }

                return Task.CompletedTask;
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Related: R5T.L0093.O000.IHasFilePathContextOperations.Verify_File_Exists()
        /// </remarks>
        public Func<TContext, Task> Verify_SolutionFile_Exists<TContext>(
            out IChecked<IFileExists> solutionFilePathChecked)
            where TContext : IHasSolutionFilePath
        {
            solutionFilePathChecked = Checked.Check<IFileExists>();

            return context =>
            {
                var solutionFileExists = Instances.FileSystemOperator.Exists_File(
                context.SolutionFilePath);

                if (!solutionFileExists)
                {
                    throw new Exception($"Solution file does not exist:\n\t{context.SolutionFilePath}");
                }

                return Task.CompletedTask;
            };
        }
    }
}
