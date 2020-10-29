import React, { useState, useEffect } from 'react';
const child = require('child_process');
// Importing Material-UI components
import {
  Button,
  CssBaseline,
  Link,
  List,
  makeStyles,
  Paper,
  Snackbar,
  ThemeProvider,
} from '@material-ui/core';
import { ClearAll as ClearAllIcon, FileCopy as FileCopyIcon } from '@material-ui/icons';
import Alert from '@material-ui/lab/Alert';
import theme from './AppTheme';

import FileListItem from './FileListItem';

const useStyles = makeStyles((theme) => ({
  root: {
    '& > *': {},
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
    justifyContent: 'space-between',
    height: '100vh',
    padding: 40,
    userSelect: 'none',
  },
  input: {
    display: 'none',
  },
  button: {
    height: 70,
    minWidth: 220,
  },
  selectButton: {
    top: '42vh',
    zIndex: 100,
  },
  fileList: {
    height: '100%',
    width: '80vw',
    marginBottom: theme.spacing(3),
    overflow: 'auto',
  },
  wsCopyright: {
    fontSize: 12,
    position: 'absolute',
    bottom: 4,
    right: 6,
    userSelect: 'none',
  },
  appVersion: {
    fontSize: 12,
    position: 'absolute',
    bottom: 20,
    right: 6,
    userSelect: 'none',
  },
}));

export default function App() {
  document.title = require('../../package.json').productName;
  const classes = useStyles();

  // Handling components display
  const [showButton, setShowButton] = useState(true);
  const [showList, setShowList] = useState(false);
  const [flashMessage, setFlashMessage] = useState({ show: false, severity: 'error', message: '' });

  const closeFlashMessage = () => {
    setFlashMessage({ show: false });
  };

  // Handling files seleciton
  const [fileList, setFileList] = useState([]);
  const handleFiles = (evt) => {
    if (evt.target.files.length < 2) {
      setFlashMessage({ show: true, severity: 'error', message: 'ERROR: Select at least 2 files' });
    } else {
      let files = []; // Creating local array
      for (var i = 0, f; (f = evt.target.files[i]); i++) {
        // Populating files in list
        files.push(f);
      }
      // After looping through file list, send it to state variable
      setFileList(files);
    }
    evt.target.value = '';
    // console.log(evt);
  };

  const handleClear = () => {
    setFileList([]);
  };

  const handleMerge = () => {
    // Handling environment
    let mergecapRelaPath = 'resources/'; // after build
    if (
      process.defaultApp ||
      /[\\/]electron-prebuilt[\\/]/.test(process.execPath) ||
      /[\\/]electron[\\/]/.test(process.execPath)
    ) {
      mergecapRelaPath = 'src/lib/mergecap/'; // during dev
    }

    // Mounting Save Dialog
    const dialog = require('electron').remote.dialog;
    const path = require('path');
    dialog
      .showSaveDialog({
        title: 'Select destination file',
        // defaultPath: path.join(__dirname, '../assets/sample.txt'),
        defaultPath: path.join(__dirname, 'CaptureMerged.cap'),
        buttonLabel: 'Save',
        // Restricting the user to only Text Files.
        filters: [
          {
            name: 'Wireshark Capture File',
            extensions: ['cap', 'pcap', 'pcapng'],
          },
        ],
        properties: [],
      })
      .then((destFile) => {
        const mergecap = `${mergecapRelaPath}mergecap.exe`;

        // Mounting array with all arguments to be passed to mergecap.exe
        let procArguments = ['-w', destFile.filePath];
        // Parsing all source files and push to arguments array
        fileList.map((f) => {
          procArguments.push(f.path);
        });

        // Calling the child process (required on top)
        child.execFile(mergecap, procArguments, function (err, data) {
          if (err) {
            console.error(err);
            setFlashMessage({
              show: true,
              severity: 'error',
              message: 'ERROR MERGING FILES!' + err,
            });
            return;
          } else {
            handleClear();
            setFlashMessage({
              show: true,
              severity: 'success',
              message: 'YES! Files sucessfuly merged',
            });
            child.exec('C:\\Windows\\explorer.exe /select,' + destFile.filePath);
          }
        });
      });
  };

  useEffect(() => {
    const handleFileListChange = () => {
      if (fileList.length < 2) {
        if (fileList.length > 0) {
          setFlashMessage({
            show: true,
            severity: 'error',
            message: 'ERROR: Select at least 2 files',
          });
        }
        setShowButton(true);
        setShowList(false);
      } else {
        // Hiding button after selecting files
        setShowButton(false);
        setShowList(true);
      }
    };
    handleFileListChange();
  }, [fileList]);

  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      {/* Button opens a dialog for selecting files */}
      <div className={classes.root}>
        <input
          accept='.cap,.pcap,.pcapng'
          className={classes.input}
          id='contained-button-file'
          multiple
          type='file'
          onChange={handleFiles}
        />
        <label htmlFor='contained-button-file'>
          <Button
            variant='contained'
            color='primary'
            className={`${classes.button} ${classes.selectButton}`}
            startIcon={<FileCopyIcon />}
            component='span'
            style={{ display: showButton ? 'inline-flex' : 'none' }}
            size='large'
          >
            Select packet capture files
          </Button>
        </label>
        <Paper
          style={{ display: showList ? 'block' : 'none' }}
          className={classes.fileList}
          elevation={1}
        >
          <List>
            {fileList.map((file) => {
              return (
                <FileListItem
                  file={file}
                  key={file.path}
                  onClick={() => {
                    const newList = fileList.filter((thisFile) => thisFile.path !== file.path);
                    setFileList(newList);
                  }}
                />
              );
            })}
          </List>
        </Paper>
        <div>
          <Button
            variant='contained'
            color='default'
            className={classes.button}
            startIcon={<ClearAllIcon />}
            component='span'
            style={{ display: showButton ? 'none' : 'inline-flex' }}
            size='large'
            onClick={handleClear}
          >
            Clear
          </Button>
          <Button
            variant='contained'
            color='secondary'
            className={classes.button}
            startIcon={<FileCopyIcon />}
            component='span'
            style={{ display: showButton ? 'none' : 'inline-flex', marginLeft: 10 }}
            size='large'
            onClick={handleMerge}
          >
            Merge Files
          </Button>
        </div>

        <Snackbar
          anchorOrigin={{
            vertical: 'bottom',
            horizontal: 'left',
          }}
          open={flashMessage.show}
          autoHideDuration={5000}
          onClose={closeFlashMessage}
        >
          <Alert severity={flashMessage.severity}>{flashMessage.message}</Alert>
        </Snackbar>
        <div className={classes.wsCopyright}>
          Wireshark mergecap is distributed under the GNU GPLv2 (
          <Link
            color='textSecondary'
            underline='hover'
            style={{ cursor: 'pointer' }}
            onClick={() => {
              child.execFile('C:\\Windows\\explorer.exe', [
                'https://github.com/wireshark/wireshark',
              ]);
            }}
          >
            https://github.com/wireshark/wireshark
          </Link>
          )
        </div>
        <div className={classes.appVersion}>
          {require('../../package.json').productName + ' ' + require('../../package.json').version}{' '}
          (
          <Link
            color='textSecondary'
            underline='hover'
            style={{ cursor: 'pointer' }}
            onClick={() => {
              child.execFile('C:\\Windows\\explorer.exe', [
                'https://github.com/gugabguerra/wireshark-merge',
              ]);
            }}
          >
            https://github.com/gugabguerra/wireshark-merge
          </Link>
          )
        </div>
      </div>
    </ThemeProvider>
  );
}
