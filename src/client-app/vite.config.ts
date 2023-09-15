import {defineConfig} from 'vite'
import react from '@vitejs/plugin-react-swc'

export default defineConfig({
    plugins: [react()],
    server: {
        strictPort: true,
        port: 4044
    },
    preview: {
        strictPort: true,
        port: 80
    }
})
