let eventCounter = 0;

// TODO: What happens if we move the <script> tag in the html file to near the top of the document.
// TODO: Don't subscribe to events until the DOM has been fully loaded
  subscribeToMouseEvents();
  subscribeToOtherEvents();
  subscribeToFormEvents();

function subscribeToOtherEvents() {
  document.getElementById('heading1').addEventListener('click', (e) => {
    const main = document.getElementById('main');
    if (main.style.display == 'none') {
      main.style.display = 'block';
      e.target.innerText = '🔼Heading 1';
    } else {
      main.style.display = 'none';
      e.target.innerText = '🔽Heading 1';
    }
  });
}
// 


// recursively subscribe to all mousemove, mouseover, mouseenter and mouseleave events
// for all elements
function subscribeToMouseEvents(element) {
  // If called without parameters, start at the body
  if (element === undefined) {
    subscribeToMouseEvents(document.querySelector('body'));
    return;
  }

  // We got an element to subscribe to. Hook up the events.
  element.addEventListener('mousemove', (ev) => {
    HandleMouseEvent(ev);
  });
  element.addEventListener('mouseenter', (ev) => {
    HandleMouseEvent(ev);
  });
  element.addEventListener('mouseleave', (ev) => {
    HandleMouseEvent(ev);
  });
  element.addEventListener('mouseover', (ev) => {
    HandleMouseEvent(ev);
  });

  // Recurse to all the child elements
  let children = element.children;
  for (let i = 0; i < children.length; i++) {
    subscribeToMouseEvents(children[i]);
  }
}

function HandleMouseEvent(mouseEvent) {
  eventCounter++;
  // TODO: Stop Propagation to see what happens to the events

  console.log(
    `${eventCounter}:${mouseEvent.type} occurred on: ${mouseEvent.target.tagName}#${mouseEvent.target.id}, handled by: ${mouseEvent.currentTarget.tagName}#${mouseEvent.currentTarget.id} at (${mouseEvent.clientX}, ${mouseEvent.clientY})`);
}


function subscribeToFormEvents(){
  /***********************************
   * Name Field
   **********************************/
  let name = document.getElementById('name');
  name.addEventListener('change', 
    (e) => {
      document.getElementById('nameMsg').innerText = `Name was changed to ${e.target.value}`;
      e.target.style.backgroundColor = 'green';
    }
  );
  name.addEventListener('focus',
    (e) => {
      e.target.style.backgroundColor = 'white';
    }
  );

  /***********************************
   * Title Field
   **********************************/
  let title = document.getElementById('title');
  title.addEventListener('focus', 
    (e) => {
      document.getElementById('titleMsg').innerText = `Title got focus`;
      e.target.style.backgroundColor = 'yellow';
    }
  );
  title.addEventListener('blur',
    (e) => {
      document.getElementById('titleMsg').innerText = `Title got blurred`;
      e.target.style.backgroundColor = 'white';
    }
  );

  /***********************************
   * State Field
   **********************************/
  let state = document.getElementById('state');
  state.addEventListener('change', 
    (e) => {
      document.getElementById('stateMsg').innerText = `State was changed to ${e.target.value}`;
    }
  );

  /***********************************
   * Submit button
   **********************************/
  let form = document.getElementById('form');
  form.addEventListener('submit', 
    (e) => {
      document.getElementById('submitMsg').innerText = 
      `Do something with { ${document.getElementById('name').value},${document.getElementById('title').value},${document.getElementById('state').value} }`;

      // TODO: We better prevent the default behavior here, or the form will get submitted!
    }
  );

}