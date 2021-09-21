module.exports = {
    purge: {
        enabled: false,
        content: [
            './**/*.html',
            './**/*.razor'
        ]
    },
    darkMode: false, // or 'media' or 'class'
    theme: {
        extend: {},
    },
    variants: {
        extend: {
            opacity: ['disabled'],
        }
    },
    plugins: [
        require('@tailwindcss/forms'),
    ],
}
