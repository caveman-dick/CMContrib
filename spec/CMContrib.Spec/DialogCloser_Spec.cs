﻿using System;
using System.Windows;
using Caliburn.Micro.Contrib;
using Machine.Fakes;
using Machine.Fakes.Adapters.Moq;
using Machine.Specifications;

namespace CMContrib.Spec
{
    [Subject(typeof(DialogCloser))]
    public class DialogCloser_Spec : WithFakes<MoqFakeEngine>
    {
        protected static Window Window;

        Establish context = () => Window = new Window();

        [Subject(typeof(DialogCloser))]
        public class when_set_on_a_dialog_window : DialogCloser_Spec
        {
            static Exception Exception;

            /// <summary>
            /// Since we cannot moq the window, we have to do it the ugly way
            /// </summary>
            Because of = () => Exception = Catch.Exception(() => Window.SetValue(DialogCloser.DialogResultProperty, true));

            It sets_the_dialog_result_of_the_window = () => Exception.ShouldBe(typeof(InvalidOperationException));
        }
    }
}
