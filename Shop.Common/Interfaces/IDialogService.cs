﻿namespace Shop.Common.Interfaces
{
    using System;
    public interface IDialogService
    {
        void Alert(
            string message, 
            string title, 
            string okbtnText);

        void Alert(
        string message,
        string title,
        string okbtnText,
        Action confirmed);

        void Confirm(
            string title, 
            string message, 
            string okButtonTitle, 
            string dismissButtonTitle, 
            Action confirmed, 
            Action dismissed);
    }
}
