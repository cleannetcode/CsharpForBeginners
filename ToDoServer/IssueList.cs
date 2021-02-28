using System;

namespace ToDoServer
{
    public class IssueList
    {
        private Issue[] _issues;

        public IssueList(int max)
        {
            _issues = new Issue[max];

            _issues[0] = new Issue
            {
                Title = "TEST1"
            };

            _issues[1] = new Issue
            {
                Title = "TEST2"
            };

            _issues[2] = new Issue
            {
                Title = "TEST3"
            };

            _issues[3] = new Issue
            {
                Title = "TEST4"
            };
        }

        public Issue[] GetIssues()
        {
            int issuesCount = Count();
            Issue[] result = new Issue[issuesCount];

            for (int i = 0; i < issuesCount; i++)
            {
                result[i] = _issues[i];
            }

            return result;
        }

        public void Add(Issue newIssue)
        {
            int nextIssueIndex = Count();
            _issues[nextIssueIndex] = newIssue;
        }

        private int Count()
        {
            int counter = 0;

            for (int i = 0; i < _issues.Length; i++)
            {
                if (_issues[i] != null)
                {
                    counter++;
                }
            }

            return counter;
        }

        public void EditTitle(int selectedIssueNumber, string newTitle)
        {
            if (selectedIssueNumber > 0 && string.IsNullOrWhiteSpace(newTitle) == false)
            {
                _issues[selectedIssueNumber - 1].Title = newTitle;
            }
        }

        public void Delete(int selectedIssueNumber)
        {
            throw new NotImplementedException();
            //int issueIndexToRemove = selectedIssueNumber - 1;

            //_issues[issueIndexToRemove] = null;
            //int issuesCount = Count();

            //for (int i = issueIndexToRemove; i <= issuesCount - issueIndexToRemove; i++)
            //{
            //    _issues[i] = _issues[i + 1];
            //}
        }
    }
}
