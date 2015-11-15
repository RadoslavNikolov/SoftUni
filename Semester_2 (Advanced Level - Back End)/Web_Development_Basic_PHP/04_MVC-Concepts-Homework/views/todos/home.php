<?php if($model-> getUser() === null): ?>
    <h1>not logged</h1>
<?php else: ?>
    <form action="" class="form-horizontal col-md-12" method="post">
            <div class="form-group col-md-6">
                <span class="col-lg-10">
                    <input type="text" class="form-control" id="username" name="todo-item" placeholder="todo item">
                </span>
                <input type="submit" name="Add" value="Add" class="btn btn-primary">
            </div>
    </form>

    <fieldset class="col-md-12">
        <legend>Todos (<?= count($model->getTodos()); ?>)</legend>
        <ol class=" list-group col-md-6">
            <?php foreach($model->getTodos() as $todo): ?>
                <li class="list-group-item col-md-12">
                    <span>
                        <?= $todo['todo_item'] ?>
                    </span>
                    <span class="badge">
                        <a href="<?= \Framework\Helpers\Helpers::url() . 'todos/delete/' . $todo['id'] ?>">X</a>
                    </span>
                </li>
            <?php endforeach; ?>
        </ol>
    </fieldset>
<?php endif; ?>


