import {Button, Result} from "antd";
import {Link} from "react-router-dom";

export const ErrorPage = () => {
    return (
        <div
            style={{
                width: '100vw',
                height: '100vh',
                display: 'flex',
                justifyContent: 'space-between',
                flexDirection: 'column'

            }}
        >
            <Result
                status="error"
                title="Page not found"
                subTitle="Please check the path to the content"
                style={{flex: 'auto'}}
                extra={[
                    <Link to={"/"}>
                        <Button type="primary" key="console">
                            Go back
                        </Button>
                    </Link>
                ]}
            >
            </Result>
        </div>
    );
};