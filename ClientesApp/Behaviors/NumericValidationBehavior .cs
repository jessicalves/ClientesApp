using System.Globalization;
using System.Text.RegularExpressions;

namespace ClientesApp.Behaviors
{
    public class NumericValidationBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            if (sender is Entry entry)
            {
                var newText = Regex.Replace(args.NewTextValue, @"[^\d]", "");

                if (newText != args.NewTextValue)
                {
                    entry.Text = newText;
                }
            }
        }
    }
}
