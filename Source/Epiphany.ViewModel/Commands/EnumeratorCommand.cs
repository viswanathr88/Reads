using Epiphany.Model.Collections;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Epiphany.ViewModel.Commands
{
    sealed class EnumeratorCommand<T> : AsyncCommand<IEnumerable<T>, IAsyncEnumerator<T>>
    {
        private readonly int itemsCount = 0;

        public EnumeratorCommand()
        {
            itemsCount = -1;
        }
        public EnumeratorCommand(int itemsCount)
        {
            if (itemsCount <= 0)
            {
                throw new ArgumentOutOfRangeException("itemsCount");
            }

            this.itemsCount = itemsCount;
        }
        public override bool CanExecute(IAsyncEnumerator<T> param)
        {
            return true;
        }

        protected override async Task RunAsync(IAsyncEnumerator<T> enumerator)
        {
            IList<T> list = new List<T>();
            int k = itemsCount;

            while ((k-- != 0) && await enumerator.MoveNext())
            {
                list.Add(enumerator.Current);
            }

            Result = list;
        }
    }
}
