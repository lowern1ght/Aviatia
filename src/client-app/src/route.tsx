import {ErrorPage} from "./pages/ErrorPage";
import {LoginPage, LoginPageProp} from "./pages/LoginPage";

import {createBrowserRouter} from "react-router-dom";
import {titleCase} from "./utilities";

const emailText : string = 'email'
const passwordText : string = 'password'

const LoginPageProps : LoginPageProp = {
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

export const router = createBrowserRouter([
    {
        path: '/',
        element: <></>,
        errorElement: <ErrorPage/>
    },
    {
        path: '/login',
        element: <LoginPage {...LoginPageProps}/>
    }
])