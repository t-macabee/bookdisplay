/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    "./src/**/*.{html,js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      gridTemplateColumns: {
        '3': 'repeat(3, minmax(0, 1fr))',
      },
      padding: {
        'screen-side': '15%',
      }
    },
  },
  plugins: [],
}

