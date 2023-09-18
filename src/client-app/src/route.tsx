import {ErrorPage} from "./pages/ErrorPage";
import {LoginPage, ILoginPageProp} from "./pages/LoginPage";

import {createBrowserRouter} from "react-router-dom";
import {titleCase} from "./utilities";

const emailText : string = 'email'
const passwordText : string = 'password'

const LoginPageProps : ILoginPageProp = {
    email : {
        type: emailText,
        title: titleCase(emailText),
        placeholder: titleCase(emailText)
    },
    password: {
        type: passwordText,
        title: titleCase(passwordText),
        placeholder: titleCase(passwordText),
    }
}

const BrowserRouter = createBrowserRouter([
    {
        path: '/',
        element: <></>,
        errorElement: <ErrorPage/>
    },
    {
        path: '/login',
        element: <LoginPage /*{...LoginPageProps}*//>
    }
])

export { BrowserRouter, LoginPageProps }