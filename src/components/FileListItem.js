import React from 'react';

// Importing Material-UI components
import {
  makeStyles,
  Avatar,
  ListItem,
  ListItemAvatar,
  ListItemText,
  ListItemSecondaryAction,
  IconButton,
  Divider,
} from '@material-ui/core';
import { Delete as DeleteIcon, FileCopy as FileCopyIcon } from '@material-ui/icons';
import convertBytes from '../lib/convert-bytes';

const useStyles = makeStyles(() => ({
  fileListItemText: {
    overflowWrap: 'break-word',
  },
}));

const FileListItem = ({ file, onClick }) => {
  const classes = useStyles();
  /* Files list to be populated after selecting files */

  return (
    <React.Fragment>
      <ListItem component='li'>
        <ListItemAvatar>
          <Avatar>
            <FileCopyIcon />
          </Avatar>
        </ListItemAvatar>
        <ListItemText
          primary={file.path}
          secondary={convertBytes(file.size)}
          className={classes.fileListItemText}
        />
        <ListItemSecondaryAction>
          <IconButton edge='end' aria-label='delete' onClick={onClick}>
            <DeleteIcon />
          </IconButton>
        </ListItemSecondaryAction>
      </ListItem>
      <Divider light variant='middle' />
    </React.Fragment>
  );
};

export default FileListItem;
