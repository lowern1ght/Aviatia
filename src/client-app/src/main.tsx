import './index.css'

import React from 'react'
import ReactDOM from 'react-dom/client'
import {RouterProvider} from "react-router-dom";

import {BrowserRouter} from "./route";

export const title = 'Aviatia'

ReactDOM.createRoot(document.getElementById('root')!).render(
    <React.StrictMode>
        <RouterProvider router={BrowserRouter}/>
    </React.StrictMode>,
)