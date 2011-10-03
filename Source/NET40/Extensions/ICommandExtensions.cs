﻿using System;
using System.Collections.Specialized;
using System.Windows.Input;
using System.Diagnostics.Contracts;

namespace Codeplex.Reactive.Extensions
{
    public static class ICommandExtensions
    {
        /// <summary>Converts CanExecuteChanged to an observable sequence.</summary>
        public static IObservable<EventArgs> CanExecuteChangedAsObservable<T>(this T source)
            where T : ICommand
        {
            Contract.Requires<ArgumentNullException>(source != null);
            Contract.Ensures(Contract.Result<IObservable<EventArgs>>() != null);

            return ObservableEx.FromEvent<EventHandler, EventArgs>(
                h => (sender, e) => h(e),
                h => source.CanExecuteChanged += h,
                h => source.CanExecuteChanged -= h);
        }
    }
}