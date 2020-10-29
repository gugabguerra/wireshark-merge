import { createMuiTheme } from '@material-ui/core/styles';
import { purple, green, red, grey } from '@material-ui/core/colors';
//import 'fontsource-oxygen';

const theme = createMuiTheme({
  typography: {
    fontFamily: [
      'Oxygen',
      '-apple-system',
      'BlinkMacSystemFont',
      '"Segoe UI"',
      'Roboto',
      '"Helvetica Neue"',
      'Arial',
      'sans-serif',
      '"Apple Color Emoji"',
      '"Segoe UI Emoji"',
      '"Segoe UI Symbol"',
    ].join(','),
  },
  palette: {
    primary: {
      main: purple[400],
    },
    secondary: {
      main: green[400],
      contrastText: 'white',
    },
    error: {
      main: grey[50],
      contrastText: 'white',
    },
  },
  overrides: {
    MuiButton: {
      root: {
        borderRadius: 1,
      },
    },
    MuiPaper: {
      rounded: {
        borderRadius: 2,
      },
    },
    MuiAlert: {
      standardError: {
        backgroundColor: red[700],
        color: 'white',
        icon: {
          color: grey[300],
        },
      },
      standardSuccess: {
        backgroundColor: green[300],
      },
    },
    MuiCssBaseline: {
      '@global': {
        html: {
          WebkitFontSmoothing: 'auto',
          fontFamily: [
            'Oxygen',
            '-apple-system',
            'BlinkMacSystemFont',
            '"Segoe UI"',
            'Roboto',
            '"Helvetica Neue"',
            'Arial',
            'sans-serif',
            '"Apple Color Emoji"',
            '"Segoe UI Emoji"',
            '"Segoe UI Symbol"',
          ].join(','),
        },
      },
    },
  },
});

export default theme;
