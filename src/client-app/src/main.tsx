import './index.css'

import React from 'react'
import ReactDOM from 'react-dom/client'
import {RouterProvider} from "react-router-dom";

import {BrowserRouter} from "./route";

ReactDOM.createRoot(document.getElementById('root')!).render(
    <React.StrictMode>
        <RouterProvider router={BrowserRouter}/>
    </React.StrictMode>,
)