import {ErrorPage} from "./pages/ErrorPage";
import {LoginPage} from "./pages/LoginPage";

import {createBrowserRouter} from "react-router-dom";

export const router = createBrowserRouter([
    {
        path: '/',
        element: <></>,
        errorElement: <ErrorPage/>
    },
    {
        path: '/login',
        element: <LoginPage/>
    }
])