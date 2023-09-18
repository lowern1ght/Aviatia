import {/*Button,*/ Form, /*FormRule, Input*/} from "antd";

import "./styles/LoginPageStyle.css"
import {IInput} from "../interfaces/IInput";

export interface ILoginPageProp {
    readonly email: IInput
    readonly password: IInput,
}

/*const InputFormComponent = (input : IInput) => {
    return (
        <div className='_form-item'>
            <p>{input.title}</p>
            <Input
                size={'middle'}
                type={input.type}
                placeholder={input.placeholder}
            />
        </div>
    )
}*/

/*const ruleRequire : FormRule = {
    type: 'string',
    required: true,
}*/

export const LoginPage = (/*{email, password}: ILoginPageProp*/) => {

    const submitHandler = () => {

    }

    return (
        <div className="_main">
            <Form className="_form" onFinish={submitHandler}>

            </Form>
        </div>
    )
}