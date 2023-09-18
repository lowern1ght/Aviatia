import {Button, Form, Input, Typography} from "antd";
import FormItem from "antd/es/form/FormItem";

import "./styles/LoginPageStyle.css"
import {IInput} from "../interfaces/IInput";


export interface LoginPageProp {
    readonly email: IInput
    readonly password: IInput,
}

export const LoginPage = ({ email, password }: LoginPageProp) => {
    return (
        <div className="_main">
            <Form className="_form">
                <Form.Item>
                    <Typography.Title>
                        Sign in
                    </Typography.Title>
                </Form.Item>

                <FormItem
                    name={'email'}
                    required={true}
                >
                    <div className='_form-item'>
                        <p>{email.title}</p>
                        <Input
                            type={email.type}
                            placeholder={email.placeholder}
                        />
                    </div>
                </FormItem>

                <FormItem
                    name={'password'}
                    required={true}
                >
                    <div className='_form-item'>
                        <p>{password.title}</p>
                        <Input
                            type={password.type}
                            placeholder={password.placeholder}
                        />
                    </div>
                </FormItem>

                <Form.Item>
                    <Button type={"primary"} htmlType={"submit"}>
                        Login
                    </Button>
                </Form.Item>

                <div
                    style={{opacity: '0.25', width: 'auto', textAlign: 'center'}}
                >
                    lowern1ght Aviatia@2023
                </div>
            </Form>
        </div>
    );
};